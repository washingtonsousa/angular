using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.UserProfiles;
using System;
using System.Collections.Generic;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Helpers;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Linq;

namespace HRWeb.Controllers
{
  /// <summary>
  /// Controller que contém métodos Helpers que auxiliam em processos Ajax do sistema
  /// que buscam informações do Sahrepoint no contexto do site Sharepoint do Add-in instalado
  /// </summary>

  [Authorize(Roles = "Administrador")]
  public class SPUsersController : BasicApiAppController
    {

        private UsuarioRepository usuarioRepo;
        public SPUsersController()
        { 
      usuarioRepo = new UsuarioRepository();
 
      this.spAuthHelper = new BasicAuthHelper();
         }

        [HttpOptions]
        [HttpGet]
        public IHttpActionResult Get()
        {
      ClientContext clientContext = TokenHelper.GetClientContextWithAccessToken(this.contextAppUrl, this.spAuthHelper.GetSPAppToken());
      SPUserRepository spUserRepository = new SPUserRepository(clientContext);
      return Ok(spUserRepository.GetSPUsers());

        } 
    }
}
