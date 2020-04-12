using System;
using System.Collections.Generic;
using System.IO;
using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class ArquivoController : BasicApiAppController
  {

    private IArquivoAppService _arquivoAppService;

    public ArquivoController(IDomainNotificationHandler<DomainNotification> domainNotification, IArquivoAppService arquivoAppService)  :base(domainNotification)
    {
      _arquivoAppService = arquivoAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public HttpResponseMessage Get()
    {

      IList<Arquivo> Arquivos = _arquivoAppService.Get();
      return ResponseWithNotifications(Arquivos);

    }


    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpGet]
    public HttpResponseMessage GetSingle()
    {

      IList<Arquivo> Arquivos = _arquivoAppService.GetSingle();
      return ResponseWithNotifications(Arquivos);


    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {
      _arquivoAppService.Delete(Id);
      return ResponseWithNotifications(Id);
    }


    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage DownloadSingle(int Id)
    {
      return ResponseWithNotifications(_arquivoAppService.DownloadSingle(Id));
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Download(int Id)
    {

      return ResponseWithNotifications(_arquivoAppService.Download(Id));

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public async Task<HttpResponseMessage> PostByUserId()
    {
      _arquivoAppService.SaveFileByUserId();
      return ResponseWithNotifications();
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public async Task<HttpResponseMessage> Post()
    {

      _arquivoAppService.SaveFileByMatricula();
      return ResponseWithNotifications();

    }

  }
}
