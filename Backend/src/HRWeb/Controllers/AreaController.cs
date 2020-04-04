using System.Collections.Generic;
using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using System.Net.Http;

namespace HRWeb.Controllers
{
  [Authorize(Roles = "Administrador")]
  public class AreaController : BasicApiAppController
  {

    public IAreaAppService _areaAppService { get; }

    public AreaController(IAreaAppService areaAppService, IDomainNotificationHandler<DomainNotification> domainNotification) : base(domainNotification)
    {


      _areaAppService = areaAppService;


    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpOptions]
    [ResponseType(typeof(IList<Area>))]
    public HttpResponseMessage Get()
    {

      IList<Area> Areas = _areaAppService.Get();
      return ResponseWithNotifications(Areas);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public HttpResponseMessage Get(int Id)
    {

      Area Area = _areaAppService.Get(Id);
      return ResponseWithNotifications(Area);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Area"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public HttpResponseMessage Post([FromBody]Area Area)
    {
      _areaAppService.Insert(Area);
      return ResponseWithNotifications(Area);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [HttpOptions]
    [ResponseType(typeof(object))]
    public HttpResponseMessage Delete(int Id)
    {

      _areaAppService.Delete(Id);
      return ResponseWithNotifications();
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="Area"></param>
    /// <returns></returns>
    [HttpPut]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public HttpResponseMessage Put([FromBody]Area Area)
    {

      _areaAppService.Update(Area);
      return ResponseWithNotifications(Area); ;

    }
  }
}
