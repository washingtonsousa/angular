using Core.Application.Interfaces;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {



        public int GetUsuarioLogadoId()
        {
            OwinContext context = (OwinContext)HttpContext.Current.GetOwinContext();
            ClaimsPrincipal user = context.Authentication.User;

            if(user.Identity.IsAuthenticated)
            return int.Parse(user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value);


            return 0;
        }


    }
}
