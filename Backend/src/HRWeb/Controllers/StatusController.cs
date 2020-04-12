using System.Collections.Generic;
using System.Linq;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  [Authorize(Roles = "Administrador")]
  public class StatusController : BasicApiAppController
  {


    private IStatusAppService _statusAppService;

    public StatusController(IDomainNotificationHandler<DomainNotification> domainNotification, IStatusAppService statusAppService) : base(domainNotification)
    {
      _statusAppService = statusAppService;
    }

    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage Get()
    {
      IList<Status> Status = _statusAppService.Get();
      return ResponseWithNotifications(Status);
    }

    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage Get(int Id)
    {

      Status Status = _statusAppService.Get(Id);
      return ResponseWithNotifications(Status);

    }
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Status Status)
    {
       Status = _statusAppService.Insert(Status);

      return ResponseWithNotifications(Status);

    }
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
    {
       _statusAppService.Delete(Id);

      return ResponseWithNotifications(Id);
    }

    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]Status Status)
    {
      Status = _statusAppService.Update(Status);

      return ResponseWithNotifications(Status);

    } // Fim do método

  } //´Classe

} // Namespace
