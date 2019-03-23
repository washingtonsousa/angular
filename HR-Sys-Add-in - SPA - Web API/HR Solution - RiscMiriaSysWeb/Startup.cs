using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RiscServicesHRSharepointAddIn.App_Start;
using RiscServicesHRSharepointAddIn.Helpers;
using System;
using System.Web.Http;


namespace RiscServicesHRSharepointAddIn
{
  public partial class Startup  
	{

        public static OAuthAuthorizationServerOptions OAuthOptions { get; set; }
        public ConfigDataHelper configDataHelper { get; set; }

        public void Configuration(IAppBuilder app) {
            app.UseCors(CorsOptions.AllowAll);
            app.UseOAuthBearerTokens(OAuthOptions);
      app.Map("/signalr", map => { map.UseCors(CorsOptions.AllowAll);
        var hubConfiguration = new HubConfiguration { };
        map.RunSignalR(hubConfiguration); });

          
     
        }
   
        static Startup() {

      OAuthOptions = new OAuthAuthorizationServerOptions
      {

        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        AllowInsecureHttp = true,
        TokenEndpointPath = new Microsoft.Owin.PathString("/api/token"),
        Provider = new OAuthProvider()

            };
        }

   
   
  }
}
