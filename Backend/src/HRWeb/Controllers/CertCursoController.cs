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

  public class CertCursoController : BasicApiAppController
  {

    private ICertCursoAppService _certCursoAppService;

    public CertCursoController(IDomainNotificationHandler<DomainNotification> domainNotification, ICertCursoAppService certCursoAppService) : base(domainNotification)
    {
      _certCursoAppService = certCursoAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<CertCurso> certCursos = _certCursoAppService.Get();
      return ResponseWithNotifications(certCursos);

    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage GetSingle()
    {

      IList<CertCurso> certCursos = _certCursoAppService.GetSingle();;
      return ResponseWithNotifications(certCursos);

    }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]CertCurso CertCurso)
    {
      _certCursoAppService.InsertSingle(CertCurso);
      return ResponseWithNotifications(CertCurso);
    }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]CertCurso CertCurso)
    {

      CertCurso =  _certCursoAppService.UpdateSingle(CertCurso);
      return ResponseWithNotifications(CertCurso);
    }

    [Authorize(Roles = "Administrador,Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {
      _certCursoAppService.DeleteSingle(Id);
      return ResponseWithNotifications(Id);


    }

  }
}
