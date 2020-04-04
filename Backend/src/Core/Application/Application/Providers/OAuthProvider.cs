using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Configuration;
using Core.Data.Models;
using Core.Shared.Kernel.Events;
using Application;
using Core.Application.Aggregates;

namespace Core.App.Providers
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
                var _service = (AuthAppService) DomainEvent.Container.GetService(typeof(AuthAppService));

                string userName = context.UserName;
                string password  = context.Password;

                UsuarioAuthenticationTicketAggregate aggr = _service.Authenticate(userName, password);

                if (!aggr.Valid)
                {
                    context.SetError("Erro", "Não autorizado!");
                    return;
                }

                context.Validated(aggr.Ticket);


            }); // Fim método anônimo da Task
        }

       

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

      string clientId;
      string clientSecret;

      if (context.TryGetFormCredentials(out clientId, out clientSecret) ||
               context.TryGetBasicCredentials(out clientId, out clientSecret)) {

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
