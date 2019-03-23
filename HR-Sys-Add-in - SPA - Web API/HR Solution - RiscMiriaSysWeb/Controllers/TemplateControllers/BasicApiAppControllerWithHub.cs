using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using RiscServicesHRSharepointAddIn.Helpers;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RiscServicesHRSharepointAddIn.Controllers.TemplateControllers
{
  public class BasicApiAppControllerWithHub<THub> : ApiController where THub: IHub
  {

    protected readonly string contextAppUrl = ConfigurationManager.AppSettings["UrlContext"];
    protected BasicAuthHelper spAuthHelper;
    protected int Usuario_Id;
 


    Lazy<IHubContext> hub = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<THub>()
        );

    protected IHubContext Hub
    {
      get { return hub.Value; }
    }

    public BasicApiAppControllerWithHub()
    {
      
     

    }

    protected void SetCurrentLoggedUserHandler()
    {
      OwinContext context = (OwinContext) Request.GetOwinContext(); 
      ClaimsPrincipal user = context.Authentication.User;
      Usuario_Id = int.Parse(user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value);
    }
  }
}
