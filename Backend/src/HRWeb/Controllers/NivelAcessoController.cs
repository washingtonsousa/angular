using System;
using HRWeb.Filters;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Helpers;
using HRWeb.Strategy.Errors;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace HRWeb.Controllers
{

  public class NivelAcessoController : BasicApiAppController
  {
    private NivelAcessoRepository NivelAcessoRepo;
    private JsonResultObjHelper jsonResultObjHelper;

    public NivelAcessoController()
    {

      NivelAcessoRepo = new NivelAcessoRepository();
      jsonResultObjHelper = new JsonResultObjHelper();

    } // Fim método


    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get()
    {

      IList<NivelAcesso> NivelAcessos = NivelAcessoRepo.GetNivelAcessos();


      return Ok(NivelAcessos);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get(int id)
    {

      NivelAcesso NivelAcesso = NivelAcessoRepo.GetNivelAcessos().ToList().FirstOrDefault(n => n.Id == id);


      return Ok(NivelAcesso);

    }

    


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public IHttpActionResult Post([FromBody]NivelAcesso NivelAcesso)
    {

      NivelAcessoRepo.InsertNivelAcesso(NivelAcesso);

      return Ok(jsonResultObjHelper.getArquivoJsonResultSuccessObj());

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Delete(int id)
    {

      NivelAcesso NivelAcesso = NivelAcessoRepo.FindNivelAcessoById(id);
      if (NivelAcesso != null)
      {
        NivelAcessoRepo.DeleteNivelAcesso(NivelAcesso);
        NivelAcessoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());

      }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Put([FromBody]NivelAcesso NivelAcesso)
    {
      NivelAcesso NivelAcessoFromDb = NivelAcessoRepo.FindNivelAcessoById(NivelAcesso.Id);

      if (NivelAcessoFromDb != null)
      {
       
        NivelAcessoFromDb.Nivel = NivelAcesso.Nivel;
        NivelAcessoFromDb.Atualizado_em = DateTime.Now;
        NivelAcessoRepo.UpdateNivelAcesso(NivelAcessoFromDb);
        NivelAcessoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());

      }


      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));




    } // Fim método


  } // Classe

} // Namespace
