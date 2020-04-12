using System.Collections.Generic;
using Core.Data.Models;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  public class CategoriaConhecimentoController : BasicApiAppController
  {

    private ICategoriaConhecimentoAppService _categoriaAppService;

    public CategoriaConhecimentoController(IDomainNotificationHandler<DomainNotification> domainNotification, ICategoriaConhecimentoAppService categoriaAppService) : base(domainNotification)
    {
      _categoriaAppService = categoriaAppService;
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage Get()
    {

      IList<CategoriaConhecimento> CategoriaConhecimentos = _categoriaAppService.Get();

      return ResponseWithNotifications(CategoriaConhecimentos);

    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
    {
      _categoriaAppService.Delete(Id);
      return ResponseWithNotifications(Id);
    }


    [Authorize(Roles = "Administrador")]
    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]CategoriaConhecimento categoriaCategoriaConhecimento)
    {
     
      CategoriaConhecimento categoriaCategoriaConhecimentoFromDb = _categoriaAppService.Update(categoriaCategoriaConhecimento);
      return ResponseWithNotifications(categoriaCategoriaConhecimentoFromDb);

    }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]CategoriaConhecimento categoriaCategoriaConhecimento)
    {
      categoriaCategoriaConhecimento = _categoriaAppService.Update(categoriaCategoriaConhecimento);
      return ResponseWithNotifications(categoriaCategoriaConhecimento);
    }


  } // Fim da classe
} // Fim da namespace
