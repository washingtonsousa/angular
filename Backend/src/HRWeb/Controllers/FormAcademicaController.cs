using System;
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Filters;
using HRWeb.Controllers.TemplateControllers;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Net;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

  public class FormAcademicaController : BasicApiAppController
  {

    private IFormAcademicaAppService _formAcademicaAppService;




    public FormAcademicaController(IDomainNotificationHandler<DomainNotification> domainNotification, IFormAcademicaAppService formAcademicaAppService) : base(domainNotification)
    {
      _formAcademicaAppService = formAcademicaAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public HttpResponseMessage Get()
    {

      IList<FormAcademica> FormAcademicas = _formAcademicaAppService.Get();


      return ResponseWithNotifications(FormAcademicas);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public HttpResponseMessage GetSingle()
    {
      IList<FormAcademica> FormAcademicas = _formAcademicaAppService.GetSingle();
      return ResponseWithNotifications(FormAcademicas);

    }



    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle(FormAcademica FormAcademica)
    {
      FormAcademica = _formAcademicaAppService.InsertSingle(FormAcademica);

      return ResponseWithNotifications(FormAcademica);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage PutSingle(FormAcademica FormAcademica)
    {
      FormAcademica = _formAcademicaAppService.UpdateSingle(FormAcademica);

      return ResponseWithNotifications(FormAcademica);


    }


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage DeleteSingle(int Id)
    {

       _formAcademicaAppService.DeleteSingle(Id);

      return ResponseWithNotifications(Id);


    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post(FormAcademica FormAcademica)
    {


      FormAcademica = _formAcademicaAppService.Insert(FormAcademica);

      return ResponseWithNotifications(FormAcademica);
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put(FormAcademica FormAcademica)
    {

      FormAcademica = _formAcademicaAppService.Update(FormAcademica);

      return ResponseWithNotifications(FormAcademica);
    }


    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
    {


       _formAcademicaAppService.Delete(Id);

      return ResponseWithNotifications(Id);

    } // Fim método



  } // Classe
} // Namespace
