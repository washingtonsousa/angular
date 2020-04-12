using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{

    public class StatisticsController : BasicApiAppController
  {

    private IStatisticsAppService _statisticsAppService;

    public StatisticsController(IDomainNotificationHandler<DomainNotification> domainNotification, IStatisticsAppService statisticsAppService) : base(domainNotification)
    {
      _statisticsAppService = statisticsAppService;
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult GetUsuarioBasic()
    {

      return Ok(_statisticsAppService.GetUsuarioBasic());
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult GetEntidadesBasic()
    {

      return Ok(_statisticsAppService.GetEntidadesBasic());
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    [Route("api/Statistics/GetLogActionStatistics/{Year?}/{Month?}/{Day?}")]
    public IHttpActionResult GetLogActionStatistics(string Year = null, string Month = null, string Day = null)
    {

        

      return Ok(_statisticsAppService.GetLogActionStatistics());

    }




    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    [Route("api/Statistics/GetLogActionLimitedList/{Year?}/{Month?}/{Day?}")]
    public IHttpActionResult GetLogActionLimitedList(string Year = null, string Month = null, string Day = null)
    {

      return Ok(_statisticsAppService.GetLogActionLimitedList());

    }



  }


}
