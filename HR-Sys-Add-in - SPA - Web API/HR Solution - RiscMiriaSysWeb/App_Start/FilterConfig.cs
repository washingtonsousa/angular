using System.Web.Mvc;

namespace RiscServicesHRSharepointAddIn
{
  public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
