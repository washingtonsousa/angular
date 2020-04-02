using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
using System;

namespace HRWeb.App_Start
{
  public class WebApiConfig
    {


    public static void Register(HttpConfiguration config)
    {
      // EnableCrossSiteRequests(config);

      AddRoutes(config);

      var serializerSettings = new JsonSerializerSettings()
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
      };
      config.Formatters.JsonFormatter.SerializerSettings = serializerSettings;
      config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
      config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
      config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }

    private static void AddRoutes(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes();
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{action}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

    }

    private static void EnableCrossSiteRequests(HttpConfiguration config)
    {
      var cors = new EnableCorsAttribute(
          origins: "*",
          headers: "*",
          methods: "*");
      cors.SupportsCredentials = true;
      config.EnableCors(cors);
      /////// Configure aqui o Cross Domain Origin Policy
    }



  

  }



}
