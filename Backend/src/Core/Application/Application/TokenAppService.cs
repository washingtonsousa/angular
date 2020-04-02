using Core.Application.Interfaces;
using Core.Application.Providers;
using Core.Data.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Application
{
    public class TokenAppService : ITokenAppService
    {
        public AuthenticationTicket BuildAuthTicketForUsuario(Usuario usuario) => BuildTicket(usuario.Email, usuario.NivelAcesso.Nivel, usuario.Id.ToString());

        public AuthenticationTicket BuildAuthTicketForInstaller(string Email) => BuildTicket(Email, "Instalador", "1");

        private AuthenticationTicket BuildTicket(string email, string role, string id)
        {
            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , email),
                     new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name , id)

                };
            ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, OAuthConfigProvider.OAuthOptions.AuthenticationType);
            OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, email));

            return new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() { });
        }
    }
}
