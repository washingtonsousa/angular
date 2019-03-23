using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using System.Web.Http;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Net;
using System.Net.Http;

namespace RiscServicesHRSharepointAddIn.Controllers
{

  
  public class CategoriaConhecimentoController : BasicApiAppController
  {



    private CategoriaConhecimentoRepository categoriaCategoriaConhecimentoRepo;
    private JsonResultObjHelper jsonResultObjHelper;

    public CategoriaConhecimentoController()
    {


      categoriaCategoriaConhecimentoRepo = new CategoriaConhecimentoRepository();
      jsonResultObjHelper = new JsonResultObjHelper();

    }


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public IHttpActionResult Get()
    {

      IList<CategoriaConhecimento> CategoriaConhecimentos = categoriaCategoriaConhecimentoRepo.GetCategoriaConhecimentos();

      return Ok(CategoriaConhecimentos);

    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
    {
      CategoriaConhecimento categoriaCategoriaConhecimento = categoriaCategoriaConhecimentoRepo.FindCategoriaConhecimento(Id);
  



      if (categoriaCategoriaConhecimento != null)
      {

        if (categoriaCategoriaConhecimento.Conhecimentos.FirstOrDefault() == null)
        {
          categoriaCategoriaConhecimentoRepo.DeleteCategoriaConhecimento(categoriaCategoriaConhecimento);

        categoriaCategoriaConhecimentoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());
        }
        else
        {
          return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));
        }
      }
     

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

    }


    [Authorize(Roles = "Administrador")]
    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]CategoriaConhecimento categoriaCategoriaConhecimento)
    {
     
      CategoriaConhecimento categoriaCategoriaConhecimentoFromDb = categoriaCategoriaConhecimentoRepo.FindCategoriaConhecimento(categoriaCategoriaConhecimento.Id);

      if (categoriaCategoriaConhecimentoFromDb != null)
      {

       

          categoriaCategoriaConhecimentoFromDb.Categoria = categoriaCategoriaConhecimento.Categoria;
          categoriaCategoriaConhecimentoRepo.UpdateCategoriaConhecimento(categoriaCategoriaConhecimentoFromDb);
          categoriaCategoriaConhecimentoRepo.Save();
          return Request.CreateResponse(HttpStatusCode.OK, categoriaCategoriaConhecimentoFromDb);

        
      }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

    }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]CategoriaConhecimento categoriaCategoriaConhecimento)
    {

      if (categoriaCategoriaConhecimentoRepo.GetCategoriaConhecimentos().Where(c => c.Categoria == categoriaCategoriaConhecimento.Categoria).FirstOrDefault() == null)
      {
        categoriaCategoriaConhecimentoRepo.InsertCategoriaConhecimento(categoriaCategoriaConhecimento);

        categoriaCategoriaConhecimentoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, categoriaCategoriaConhecimento);
      }


      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));
    }


  } // Fim da classe
} // Fim da namespace
