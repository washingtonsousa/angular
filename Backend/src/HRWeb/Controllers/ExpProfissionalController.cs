using System;
using Core.Data.Repositories;
using Core.Data.Models;
using System.Web.Http;
using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class ExpProfissionalController : BasicApiAppController
  { 
    

    private IExpProfissionalAppService _expAppService;



    public ExpProfissionalController(IDomainNotificationHandler<DomainNotification> domainNotification, IExpProfissionalAppService expAppService) : base(domainNotification)
    {
      _expAppService = expAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<ExpProfissional> ExpProfissionais = _expAppService.Get();


      return ResponseWithNotifications(ExpProfissionais);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage GetSingle()
    {
      IList<ExpProfissional> ExpProfissionais = _expAppService.GetSingle();


      return ResponseWithNotifications(ExpProfissionais);

    }



    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]ExpProfissional ExpProfissional)
    {

      ExpProfissional = _expAppService.InsertSingle(ExpProfissional);


      return ResponseWithNotifications(ExpProfissional);


    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]ExpProfissional ExpProfissional)
    {

      ExpProfissional = _expAppService.UpdateSingle(ExpProfissional);


      return ResponseWithNotifications(ExpProfissional);

    }


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {
      _expAppService.DeleteSingle(Id);


      return ResponseWithNotifications(Id);


    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]ExpProfissional ExpProfissional)
    {

      ExpProfissional = _expAppService.Update(ExpProfissional);


      return ResponseWithNotifications(ExpProfissional);

    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]ExpProfissional ExpProfissional)
    {

      ExpProfissional = _expAppService.Insert(ExpProfissional);


      return ResponseWithNotifications(ExpProfissional);
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {

      _expAppService.Delete(Id);


      return ResponseWithNotifications(Id);


    }



  }
}
