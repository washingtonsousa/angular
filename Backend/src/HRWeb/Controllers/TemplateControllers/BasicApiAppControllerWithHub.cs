using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
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
  public class BasicApiAppControllerWithHub<THub> : BasicApiAppController where THub: IHub
  {

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
  }
}
