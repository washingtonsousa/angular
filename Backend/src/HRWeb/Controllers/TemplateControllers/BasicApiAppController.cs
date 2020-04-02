using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using HRWeb.Helpers;
using Core.Data.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HRWeb.Controllers.TemplateControllers
{
  public class BasicApiAppController : ApiController 
  {

    protected readonly string contextAppUrl = ConfigurationManager.AppSettings["UrlContext"];
    protected BasicAuthHelper spAuthHelper;
    protected int Usuario_Id;
    protected ConfigData config;


    public BasicApiAppController()
    {

      config = new ConfigDataHelper().getConfigDataFromConfigFile();

    }

    protected void SetCurrentLoggedUserHandler()
    {
      OwinContext context = (OwinContext) Request.GetOwinContext(); 
      ClaimsPrincipal user = context.Authentication.User;
      Usuario_Id = int.Parse(user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value);
    }
  }
}
