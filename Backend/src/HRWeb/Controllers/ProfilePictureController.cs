using Microsoft.Owin;
using HRWeb.Controllers.TemplateControllers;
using Core.Data.Models;
using Core.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

    [Authorize (Roles ="Funcionario, Administrador")]
    public class ProfilePictureController : BasicApiAppController
    {


    public IProfilePictureAppService _profilePictureAppService;


    public ProfilePictureController(IDomainNotificationHandler<DomainNotification> domainNotification, IProfilePictureAppService profilePictureAppService) : base(domainNotification)
    {
      _profilePictureAppService = profilePictureAppService;
    }

    [HttpGet]
    [HttpOptions]
    public async Task<HttpResponseMessage> GetSingle()
    {
     
      return ResponseWithNotifications(await _profilePictureAppService.GetSingle());

    }

    [HttpGet]
    [HttpOptions]
    [Route("api/ProfilePicture/Get/{id}")]
    public async Task<HttpResponseMessage> Get(int id)
    {

      return ResponseWithNotifications(await _profilePictureAppService.Get(id));

    }



    [HttpPost]
    [HttpOptions]
    public async Task<HttpResponseMessage> Post()
    {
      return ResponseWithNotifications(await _profilePictureAppService.Insert());
    }


    [HttpPut]
    [HttpOptions]
    public async Task<HttpResponseMessage> Put()
    {
      return ResponseWithNotifications(await _profilePictureAppService.Update());

    }



    [HttpDelete]
    [HttpOptions]
    public async Task<HttpResponseMessage> Delete()
    {
      await _profilePictureAppService.Delete();

      return ResponseWithNotifications();

    }

  }
}
