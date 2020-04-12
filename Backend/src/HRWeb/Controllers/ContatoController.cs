using System;
using HRWeb.Filters;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  public class ContatoController : BasicApiAppController
  {
    private IContatoAppService _contatoAppService;




    public ContatoController(IDomainNotificationHandler<DomainNotification> domainNotification, IContatoAppService contatoAppService) : base(domainNotification)
    {
      _contatoAppService = contatoAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<Contato> contatos = _contatoAppService.Get();


      return ResponseWithNotifications(contatos);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage GetSingle()
    {

      IList<Contato> contatos = _contatoAppService.GetSingle();



      return ResponseWithNotifications(contatos);

    }

    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {


      _contatoAppService.DeleteSingle(Id);



      return ResponseWithNotifications(Id);

    } // Fim método

    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle([FromBody]Contato Contato)
    {

      Contato = _contatoAppService.UpdateSingle(Contato);



      return ResponseWithNotifications(Contato);

    } //Fim método

    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]Contato Contato)
    {

      Contato = _contatoAppService.InsertSingle(Contato);



      return ResponseWithNotifications(Contato);

    }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Contato Contato)
    {


      Contato = _contatoAppService.Insert(Contato);



      return ResponseWithNotifications(Contato);

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int id)
    {


      _contatoAppService.Delete(id);



      return ResponseWithNotifications(id);

    }
    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]Contato Contato)
    {
      Contato = _contatoAppService.Update(Contato);



      return ResponseWithNotifications(Contato);




    } // Fim método


  } // Classe

} // Namespace
