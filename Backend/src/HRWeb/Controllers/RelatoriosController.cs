using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HRWeb.Filters;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Controllers.TemplateControllers;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using System.Net.Http;
using System.Net.Http.Headers;
using Core.Application.Interfaces;
using System.IO;
using Core.Application.Facades;

namespace HRWeb.Controllers
{

  [Authorize(Roles = "Administrador")]
  public class RelatoriosController : BasicApiAppController
  {
    public RelatoriosController(IDomainNotificationHandler<DomainNotification> domainNotification, IRelatoriosAppService relatoriosAppService) : base(domainNotification)
    {
      _relatoriosAppService = relatoriosAppService;
    }

    private IRelatoriosAppService _relatoriosAppService;

    public HttpResponseMessage Get(string SearchStr = null, IList<int> ConhecimentoIds = null)
    {

      HttpResponseMessage Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

      var content = _relatoriosAppService.Get();

      Response = ResponseFacade.BuildFileFromMemoryResponseMessage(new MemoryStream(content.GetAsByteArray()), "relatório.xls", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

      return Response;

    }
  }
}
