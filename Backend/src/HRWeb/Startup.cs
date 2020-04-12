using Core.Application.Providers;
using HRWeb.App_Start;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(HRWeb.Startup))]

namespace HRWeb
{


 
  public partial class Startup
  {


    public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public void Configuration(IAppBuilder app)
    {

      app.UseCors(CorsOptions.AllowAll);
      app.UseOAuthBearerTokens(OAuthOptions);
      app.Map("/signalr", map =>
      {
        map.UseCors(CorsOptions.AllowAll);
        var hubConfiguration = new HubConfiguration { };
        map.RunSignalR(hubConfiguration);
      });


      var config = new HttpConfiguration();
      // Configure Unity
      var resolver = GlobalConfiguration.Configuration.DependencyResolver;
      GlobalConfiguration.Configuration.DependencyResolver = resolver;
      config.DependencyResolver = resolver;

      // Do Web API configuration
      WebApiConfig.Register(config);


    }

    static Startup()
    {

      OAuthOptions = OAuthConfigProvider.OAuthOptions;
    }



  }
}
