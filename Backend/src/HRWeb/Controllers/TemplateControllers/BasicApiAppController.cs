using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Core.Data.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using System.Net;

namespace HRWeb.Controllers.TemplateControllers
{
  public class BasicApiAppController : ApiController 
  {

    public IDomainNotificationHandler<DomainNotification> _domainNotification { get; }

    public BasicApiAppController(IDomainNotificationHandler<DomainNotification> domainNotification){

      _domainNotification = domainNotification;

    }

    public HttpResponseMessage ResponseWithNotifications(object data = null)
    {

      if (_domainNotification.HasNotifications())
        return Request.CreateResponse(HttpStatusCode.BadRequest, _domainNotification.Notify());

      return Request.CreateResponse(HttpStatusCode.OK, data);

    }


    public HttpResponseMessage ResponseWithNotifications(HttpResponseMessage response)
    {

      if (_domainNotification.HasNotifications())
        return Request.CreateResponse(HttpStatusCode.BadRequest, _domainNotification.Notify());

      return response;

    }

  }
}
