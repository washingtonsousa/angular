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

        public AuthenticationTicket BuildAuthTicketByUsuario(Usuario usuario)
        {

            List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , usuario.Email, "Email"),
                     new Claim(ClaimTypes.Role, usuario.NivelAcesso.Nivel),
                    new Claim(ClaimTypes.Name , usuario.Id.ToString(), "Id")

                };

            ClaimsIdentity OAuthIdentity = new ClaimsIdentity(claims, OAuthConfigProvider.OAuthOptions.AuthenticationType);
            OAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));

        return new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() { });

    }
         


    }
}
