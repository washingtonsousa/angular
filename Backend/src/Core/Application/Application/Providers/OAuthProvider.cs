using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Linq;
using Core.Data.Models;
using System.Security;

namespace Core.Application.Providers
{
  public class OAuthProvider : OAuthAuthorizationServerProvider
    {
    
        private Claim AccessLevelClaim;
        private Usuario usuario;

        public OAuthProvider() {}

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("access_level", this.AccessLevelClaim.Value);

            if(this.usuario != null)
              {
                context.AdditionalResponseParameters.Add("user_id", this.usuario.Id);
                context.AdditionalResponseParameters.Add("username", this.usuario.Nome);
                context.AdditionalResponseParameters.Add("email", this.usuario.Email);
              }
            
     
            return base.TokenEndpoint(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {

            return  Task.Factory.StartNew(() =>
            {

                string userName = context.UserName;
                string password  = context.Password;

              this.usuario =  new HrDbContext().Usuarios.Include(u => u.Status).Include(u => u.NivelAcesso)
              .FirstOrDefault(u => u.Email == userName && u.Status.Codigo == 1);

        

              if (this.usuario != null
              && this.usuario.Status.Codigo == 1
              && password != null
              && new BasicAuthHelper().ValidateUserByLdapCredentials(userName, password) == true)
              {
                if (usuario.NivelAcesso.Nivel == "Administrador")
                {
                  this.AccessLevelClaim = new Claim(ClaimTypes.Role, "Administrador");
                } else
                {
                  this.AccessLevelClaim = new Claim(ClaimTypes.Role, "Funcionario");
                }

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , userName, "Email"),
                    this.AccessLevelClaim,
                    new Claim(ClaimTypes.Name , this.usuario.Id.ToString(), "Id")

                };

                ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var ticket = new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() { });

                context.Validated(ticket);

              } else if (userName == ConfigurationManager.AppSettings["InstallEmailAccount"]
              && password == ConfigurationManager.AppSettings["InstallPassword"]) {

                this.AccessLevelClaim = new Claim(ClaimTypes.Role, "Instalador");

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , userName, "Email"),
                    this.AccessLevelClaim,
                    new Claim(ClaimTypes.Name , 1.ToString(), "Id")
                };

                ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

                var ticket = new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() { });
            
                context.Validated(ticket);

              } else {

                    context.SetError("Erro", "Não autorizado!");
                }


            }); // Fim método anônimo da Task
        }

       

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

      string clientId;
      string clientSecret;

      if (context.TrygetFormCredentials(out clientId, out clientSecret) ||
               context.TrygetBasicCredentials(out clientId, out clientSecret)) {

         string clientIdFromConfig = ConfigurationManager.AppSettings["ClientId"];
         string clientSecretFromConfig = ConfigurationManager.AppSettings["ClientSecret"];

        if(clientId == clientIdFromConfig && clientSecretFromConfig == clientSecret)
        {
          context.Validated();
        } else
        {
          context.SetError("Requisição inválida!");
        }
      }
      

      return Task.FromResult<object>(null);
        }

    }
}
