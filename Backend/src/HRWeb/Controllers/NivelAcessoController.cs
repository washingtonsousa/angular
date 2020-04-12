using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Collections.Generic;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  public class NivelAcessoController : BasicApiAppController
  {
    private INivelAcessoAppService _nivelAcessoAppService;

    public NivelAcessoController(IDomainNotificationHandler<DomainNotification> domainNotification, INivelAcessoAppService nivelAcessoAppService) : base(domainNotification)
    {
      _nivelAcessoAppService = nivelAcessoAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<NivelAcesso> NivelAcessos = _nivelAcessoAppService.Get();


      return ResponseWithNotifications(NivelAcessos);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get(int id)
    {

      NivelAcesso NivelAcesso = _nivelAcessoAppService.Get(id);


      return ResponseWithNotifications(NivelAcesso);

    }




    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]NivelAcesso NivelAcesso)
    {

      NivelAcesso = _nivelAcessoAppService.Insert(NivelAcesso);

      return ResponseWithNotifications(NivelAcesso);


    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Delete(int id)
    {

      _nivelAcessoAppService.Delete(id);

      return ResponseWithNotifications(id);

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Put([FromBody]NivelAcesso NivelAcesso)
    {
      NivelAcesso = _nivelAcessoAppService.Update(NivelAcesso);
      return ResponseWithNotifications(NivelAcesso);

    } // Fim método


  } // Classe

} // Namespace
