using System;
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Filters;
using System.Web.Http;
using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  public class ResumoController : BasicApiAppController
  {

    private IResumoAppService _resumoAppService;


    public ResumoController(IDomainNotificationHandler<DomainNotification> domainNotification, IResumoAppService resumoAppService) : base(domainNotification)
    {
      _resumoAppService = resumoAppService;
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]Resumo Resumo)
    {

      _resumoAppService.InsertSingle(Resumo);

      return ResponseWithNotifications(Resumo);

    } // Fim método


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]Resumo Resumo)

    {
      Resumo = _resumoAppService.UpdateSingle(Resumo);

      return ResponseWithNotifications(Resumo);

    } // Fim método

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {
      _resumoAppService.DeleteSingle(Id);

      return ResponseWithNotifications(Id);

    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Resumo Resumo)
    {

      Resumo = _resumoAppService.Insert(Resumo);

      return ResponseWithNotifications(Resumo);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]Resumo Resumo)
    {

      Resumo = _resumoAppService.Update(Resumo);

      return ResponseWithNotifications(Resumo);

    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete([FromBody]Resumo Resumo)
    {

      _resumoAppService.Delete(Resumo);

      return ResponseWithNotifications(Resumo);
    }



  } // Fim da classe
} // Fim da namespace
