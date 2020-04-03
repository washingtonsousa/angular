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
using Core.Application.ViewModel;

namespace HRWeb.Controllers.TemplateControllers
{
  public class BasicApiAppController : ApiController 
  {

 
    public BasicApiAppController(){}


    public IHttpActionResult GetResponseWithNotifications(object data)
    {

      var response = new ResponseViewModel(data);

      return Ok(response);

    }

  }
}
