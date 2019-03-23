using Microsoft.Owin;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
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

namespace RiscServicesHRSharepointAddIn.Controllers
{

    [Authorize (Roles ="Funcionario, Administrador")]
    public class ProfilePictureController : BasicApiAppController
    {


    public UsuariosRepository usuarioRepo;

    public ProfilePictureController()
    {
      usuarioRepo = new UsuariosRepository();
    }

    [HttpGet]
    [HttpOptions]
    public async Task<HttpResponseMessage> GetSingle()
    {
      OwinContext context = (OwinContext)Request.GetOwinContext();
      ClaimsPrincipal user = context.Authentication.User;
 
      string user_id = user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value;

      Usuario usuarioFromDb = await usuarioRepo.FindUsuarioAsync(int.Parse(user_id));

      if (usuarioFromDb != null)
      {

        if (usuarioFromDb.profileImage64String != null)
        {
          return Request.CreateResponse(HttpStatusCode.OK, usuarioFromDb.profileImage64String);

        }

        return Request.CreateResponse(HttpStatusCode.NotFound, "Imagem não existe");


      }
      else
      {

        return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPUserNotFoundError()));
      }

    }

    [HttpGet]
    [HttpOptions]
    [Route("api/ProfilePicture/Get/{id}")]
    public async Task<HttpResponseMessage> Get(int id)
    {


      Usuario usuarioFromDb = await usuarioRepo.FindUsuarioAsync(id);
      if (usuarioFromDb != null)
      {

        if (usuarioFromDb.profileImage64String != null)
        {

          return Request.CreateResponse(HttpStatusCode.OK,  usuarioFromDb.profileImage64String);
        }
        return Request.CreateResponse(HttpStatusCode.NotFound, "Imagem não existe");
      }
      else
      {

        return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPUserNotFoundError()));
      }

    }



    [HttpPost]
    [HttpOptions]
    public async Task<HttpResponseMessage> Post()
    {
      OwinContext context = (OwinContext)Request.GetOwinContext();
      ClaimsPrincipal user = context.Authentication.User;

      string user_id = user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value;

      var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

      MultipartFileData Documento = null;


      if (!Request.Content.IsMimeMultipartContent())
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Conteúdo não permitido");
      }

      try
      {
        await Request.Content.ReadAsMultipartAsync(provider);
      }
      catch (System.Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }

      Documento = provider.FileData[0];

      string filetype = Documento.Headers.Where(u => u.Key == "Content-Type").FirstOrDefault().Value.FirstOrDefault();


      if (filetype != "image/jpeg" && filetype != "image/png")
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Extensão de arquivo não suportada");
      }


      Usuario usuarioFromDb = await usuarioRepo.FindUsuarioAsync(int.Parse(user_id));

      if (usuarioFromDb != null)
      {

        byte[] b = System.IO.File.ReadAllBytes(provider.FileData[0].LocalFileName);

        usuarioFromDb.profileImage64String = Convert.ToBase64String(b);
        usuarioRepo.Save();
        return Request.CreateResponse(HttpStatusCode.OK, "Executado com sucesso");
 
        }
      

      return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPUserNotFoundError()));
        

    }


    [HttpPut]
    [HttpOptions]
    public async Task<HttpResponseMessage> Put()
    {
      OwinContext context = (OwinContext)Request.GetOwinContext();
      ClaimsPrincipal user = context.Authentication.User;

      string user_id = user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value;

      var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

      MultipartFileData Documento = null;


      if (!Request.Content.IsMimeMultipartContent())
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Conteúdo não permitido");
      }

      try
      {
        await Request.Content.ReadAsMultipartAsync(provider);
      }
      catch (System.Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }


      Documento = provider.FileData[0];

      string filetype = Documento.Headers.Where(u => u.Key == "Content-Type").FirstOrDefault().Value.FirstOrDefault();


      if (filetype != "image/jpeg" && filetype != "image/png")
      {
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Extensão de arquivo não suportada");
      }

      Usuario usuarioFromDb = await usuarioRepo.FindUsuarioAsync(int.Parse(user_id));

      if (usuarioFromDb != null)
      {

        byte[] b = System.IO.File.ReadAllBytes(provider.FileData[0].LocalFileName);

        usuarioFromDb.profileImage64String = Convert.ToBase64String(b);
        usuarioRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, "Executado com sucesso");

      }


      return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPUserNotFoundError()));

    }


    [HttpDelete]
    [HttpOptions]
    public async Task<HttpResponseMessage> Delete()
    {

      OwinContext context = (OwinContext)Request.GetOwinContext();
      ClaimsPrincipal user = context.Authentication.User;

      string user_id = user.Claims.Where(u => u.ValueType == "Id").FirstOrDefault().Value;

      Usuario usuarioFromDb = await usuarioRepo.FindUsuarioAsync(int.Parse(user_id));
      usuarioFromDb.profileImage64String = null;
      usuarioRepo.Save();
      return Request.CreateResponse(HttpStatusCode.NotFound, "Arquivo não encontrado");


    }

  }
}
