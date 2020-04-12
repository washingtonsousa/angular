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
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;
using Core.Application.Sharepoint.Services;

namespace HRWeb.Controllers
{
  /// <summary>
  /// Controller que contém métodos Helpers que auxiliam em processos Ajax do sistema
  /// que buscam informações do Sahrepoint no contexto do site Sharepoint do Add-in instalado
  /// </summary>

  [Authorize(Roles = "Administrador")]
  public class SPUsersController : BasicApiAppController
  {

    private ISharepointUsersService _sharepointUsersAppService;


    public SPUsersController(IDomainNotificationHandler<DomainNotification> domainNotification, ISharepointUsersService sharepointUsersAppService) : base(domainNotification)
    {
      _sharepointUsersAppService = sharepointUsersAppService;
    }

    [HttpOptions]
    [HttpGet]
    public IHttpActionResult Get()
    {
      return Ok(_sharepointUsersAppService.Get());

    }
  }
}
