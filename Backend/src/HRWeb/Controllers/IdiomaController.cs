
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Helpers;
using HRWeb.Strategy.Errors;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System;

namespace HRWeb.Controllers
{

    public class IdiomaController : BasicApiAppController
    {
     
        private IdiomaRepository idiomaRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public IdiomaController()
        {
     
            idiomaRepo = new IdiomaRepository();
            jsonResultObjHelper = new JsonResultObjHelper();
    }

        [Authorize(Roles ="Administrador, Funcionario")]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostSingle(Idioma Idioma)
        {
      this.SetCurrentLoggedUserHandler();
      Idioma.UsuarioId = Usuario_Id;
            idiomaRepo.InsertIdioma(Idioma);
            idiomaRepo.Save();

            return Json(jsonResultObjHelper.getArquivoJsonResultSuccessObj());
        }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPut]
        public IHttpActionResult PutSingle([FromBody]Idioma Idioma)
        {


      this.SetCurrentLoggedUserHandler();
    
      Idioma IdiomaFromDb = idiomaRepo.FindIdiomaByBothIds(Idioma.Id, Usuario_Id);

            if (IdiomaFromDb !=null)
            {

        IdiomaFromDb.Nome = Idioma.Nome;
        IdiomaFromDb.Fluencia = Idioma.Fluencia;
        IdiomaFromDb.Atualizado_em = DateTime.Now;
                idiomaRepo.UpdateIdioma(IdiomaFromDb);
                idiomaRepo.Save();

                return Json(jsonResultObjHelper.getArquivoJsonResultSuccessObj());


            }
            return Json(new ErrorHelper().getError(new DatabaseNullResultError()));
          
        }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {
      this.SetCurrentLoggedUserHandler();
      Idioma IdiomaFromDb = idiomaRepo.FindIdiomaByBothIds(Id, Usuario_Id);

            if (IdiomaFromDb != null)
            {

                idiomaRepo.DeleteIdioma(IdiomaFromDb);
                idiomaRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK,jsonResultObjHelper.getArquivoJsonResultSuccessObj());

            }


      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));
        }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
        public HttpResponseMessage Post([FromBody]Idioma Idioma)
        {

            Idioma IdiomaFromDb = idiomaRepo.FindIdiomaByBothIds(Idioma.Id, Idioma.UsuarioId);

            if (IdiomaFromDb == null)
            {
                idiomaRepo.InsertIdioma(Idioma);
                idiomaRepo.Save();
        return Request.CreateResponse(HttpStatusCode.OK, Idioma);
            }


      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));
            
        }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPut]
    public HttpResponseMessage Put([FromBody]Idioma Idioma)
        {

            Idioma IdiomaFromDb = idiomaRepo.FindIdiomaByBothIds(Idioma.Id, Idioma.UsuarioId);

            if (IdiomaFromDb != null)
            {
        IdiomaFromDb.Nome = Idioma.Nome;
        IdiomaFromDb.Fluencia = Idioma.Fluencia;
                idiomaRepo.UpdateIdioma(IdiomaFromDb);
                idiomaRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, Idioma);

            }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));
        }



    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
        {
      this.SetCurrentLoggedUserHandler();
            Idioma IdiomaFromDb = idiomaRepo.FindIdiomaByBothIds(Id, Usuario_Id);

            if (IdiomaFromDb != null)
            {

                idiomaRepo.DeleteIdioma(IdiomaFromDb);
                idiomaRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());

            }
      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));
           
        }



    } // Fim da Classe
} // Namespace
