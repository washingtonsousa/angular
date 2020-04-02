using System;
using System.Web.Routing;
using System.Web.Http;
using HRWeb.App_Start;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using MultipartDataMediaFormatter;
using MultipartDataMediaFormatter.Infrastructure;
using System.Web.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;

namespace HRWeb
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {

      GlobalConfiguration.Configuration.Formatters
      .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
      GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
      .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                        "text/html",
                        stringComparison.InvariantCultureIgnoreCase,
                        true,
                        "application/json"));

      var serializerSettings = new JsonSerializerSettings();
      serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
      serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

      var serializer = JsonSerializer.Create(serializerSettings);

      GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);

      GlobalConfiguration.Configure(WebApiConfig.Register);

      AreaRegistration.RegisterAllAreas();

      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


    }
  }


}
