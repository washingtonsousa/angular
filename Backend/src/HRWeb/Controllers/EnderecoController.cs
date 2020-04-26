using System;
using HRWeb.Filters;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class EnderecoController : BasicApiAppController
  {

    private IEnderecoAppService _enderecoAppService;


    public EnderecoController(IDomainNotificationHandler<DomainNotification> domainNotification, IEnderecoAppService enderecoAppService) : base(domainNotification)
    {
      _enderecoAppService = enderecoAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<Endereco> Enderecos = _enderecoAppService.Get();


      return ResponseWithNotifications(Enderecos);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage GetSingle()
    {
      IList<Endereco> Enderecos = _enderecoAppService.GetSingle();

      return ResponseWithNotifications(Enderecos);

    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {
      _enderecoAppService.DeleteSingle(Id);
      return ResponseWithNotifications(Id);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]Endereco Endereco)
    {

      Endereco  = _enderecoAppService.UpdateSingle(Endereco);

      return ResponseWithNotifications(Endereco);
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]Endereco Endereco)
    {

      Endereco = _enderecoAppService.InsertSingle(Endereco);

      return ResponseWithNotifications(Endereco);


    } // Fim método



    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]Endereco endereco)
    {

      endereco = _enderecoAppService.Insert(endereco);
      return ResponseWithNotifications(endereco);

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {

      _enderecoAppService.DeleteSingle(Id);

      return ResponseWithNotifications(Id);
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]Endereco endereco)
    {

     endereco = _enderecoAppService.UpdateSingle(endereco);

      return ResponseWithNotifications(endereco);
    }

  } // Classe

} // Namespace
