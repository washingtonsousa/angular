using System.Collections.Generic;
using Core.Data.Models;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using System.Web.Http.Description;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{
  [Authorize(Roles = "Administrador")]
  public class DepartamentoController : BasicApiAppController
  {


    private IDepartamentoAppService _departamentoAppService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domainNotification"></param>
    /// <param name="departamentoAppService"></param>
    public DepartamentoController(IDomainNotificationHandler<DomainNotification> domainNotification,
      IDepartamentoAppService departamentoAppService) : base(domainNotification)
    {

      _departamentoAppService = departamentoAppService;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    [HttpGet]
    [ResponseType(typeof(IList<Departamento>))]
    public HttpResponseMessage Get()
    {

      IList<Departamento> departamentos = _departamentoAppService.Get();



      return ResponseWithNotifications(departamentos);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpGet]
    public HttpResponseMessage Get(int Id)
    {

      Departamento Departamento = _departamentoAppService.Get(Id);
      return ResponseWithNotifications(Departamento);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departamento"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]Departamento departamento)
    {
      var Departamento = _departamentoAppService.Insert(departamento);
      return ResponseWithNotifications(Departamento);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [ResponseType(typeof(object))]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {
      _departamentoAppService.Delete(Id);
      return ResponseWithNotifications(Id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departamento"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]Departamento departamento)
    {
      Departamento departamentoFromDb = _departamentoAppService.Update(departamento);
      return ResponseWithNotifications(departamentoFromDb);
    }
  } // Fim da classe
} // Fim da namespace
