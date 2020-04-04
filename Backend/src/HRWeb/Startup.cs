using Core.Application.Providers;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

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

    }

    static Startup()
    {

      OAuthOptions = OAuthConfigProvider.OAuthOptions;
    }



  }
}
