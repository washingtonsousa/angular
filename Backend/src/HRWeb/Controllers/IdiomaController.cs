
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class IdiomaController : BasicApiAppController
  {
    IIdiomaAppService _idiomaAppService;

    public IdiomaController(IDomainNotificationHandler<DomainNotification> domainNotification, IIdiomaAppService idiomaAppService) : base(domainNotification)
    {
      _idiomaAppService = idiomaAppService;
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle(Idioma Idioma)
    {

      Idioma = _idiomaAppService.InsertSingle(Idioma);

      return ResponseWithNotifications(Idioma);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]Idioma Idioma)
    {
      Idioma = _idiomaAppService.UpdateSingle(Idioma);

      return ResponseWithNotifications(Idioma);

    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {
      _idiomaAppService.DeleteSingle(Id);

      return ResponseWithNotifications(Id);
    }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Idioma Idioma)
    {

      Idioma = _idiomaAppService.Insert(Idioma);

      return ResponseWithNotifications(Idioma);

    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]Idioma Idioma)
    {

      Idioma = _idiomaAppService.Update(Idioma);

      return ResponseWithNotifications(Idioma);
    }



    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {
      _idiomaAppService.Delete(Id);

      return ResponseWithNotifications(Id);

    }



  } // Fim da Classe
} // Namespace
