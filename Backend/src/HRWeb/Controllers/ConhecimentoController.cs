using System.Collections.Generic;
using System.Linq;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;
using System.Net.Http;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{


  public class ConhecimentoController : BasicApiAppController
  {

    private IConhecimentoAppService _conhecimentoAppService;

    public ConhecimentoController(IDomainNotificationHandler<DomainNotification> domainNotification, IConhecimentoAppService conhecimentoAppService) : base(domainNotification)
    {
      _conhecimentoAppService = conhecimentoAppService;
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage Get()
    {

      IList<Conhecimento> Conhecimentos = _conhecimentoAppService.Get();

      return ResponseWithNotifications(Conhecimentos);

    }


    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
    {
      _conhecimentoAppService.Delete(Id);

      return ResponseWithNotifications(Id);

        }
    [Authorize(Roles = "Administrador")]
    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]Conhecimento conhecimento)
    {

      Conhecimento conhecimentoFromDb = _conhecimentoAppService.Update(conhecimento);
      return ResponseWithNotifications(conhecimentoFromDb);

    }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Conhecimento conhecimento)
    {
       conhecimento = _conhecimentoAppService.Update(conhecimento);
      return ResponseWithNotifications(conhecimento);
    }


  } // Fim da classe
} // Fim da namespace
