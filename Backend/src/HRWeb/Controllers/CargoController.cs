using System.Collections.Generic;
using Core.Data.Models;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{
  [Authorize(Roles = "Administrador")]
  public class CargoController : BasicApiAppController
  {

    private ICargoAppService _cargoAppService;

    public CargoController(IDomainNotificationHandler<DomainNotification> domainNotification, ICargoAppService cargoAppService) : base(domainNotification)
    {
      _cargoAppService = cargoAppService;
    }

    public HttpResponseMessage Get()
    {

      IList<Cargo> Cargos = _cargoAppService.Get();
      return ResponseWithNotifications(Cargos);

    }


    public HttpResponseMessage Get(int Id)
    {

      Cargo Cargo = _cargoAppService.Get(Id);
      return ResponseWithNotifications(Cargo);

    }

    [HttpPost]
    public HttpResponseMessage Post([FromBody]Cargo cargo)
    {
      Cargo Cargo = _cargoAppService.Insert(cargo);
      return ResponseWithNotifications(Cargo);
    }

    [HttpDelete]
    public HttpResponseMessage Delete(int id)
    {
      _cargoAppService.Delete(id);
      return ResponseWithNotifications(id);
    }

    [HttpPut]
    public HttpResponseMessage Put(Cargo cargo)
    {
      Cargo Cargo = _cargoAppService.Update(cargo);
      return ResponseWithNotifications(Cargo);
    }
  } // Fim da classe
} // Fim da namespace
