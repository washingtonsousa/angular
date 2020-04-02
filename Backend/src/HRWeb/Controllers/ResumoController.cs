using System;
using Core.Data.Repositories;
using Core.Data.Models;
using HRWeb.Filters;
using HRWeb.Helpers;
using HRWeb.Strategy.Errors;
using System.Web.Http;
using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;

namespace HRWeb.Controllers
{
  
    public class ResumoController : BasicApiAppController
    {
  
        private ResumoRepository resumoRepo;
        private UsuarioRepository usuarioRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public ResumoController()
        {

            resumoRepo = new ResumoRepository();
            usuarioRepo = new UsuarioRepository();
            jsonResultObjHelper = new JsonResultObjHelper();


        } // Fim mpetodo


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostSingle([FromBody]Resumo Resumo)
        {

      this.SetCurrentLoggedUserHandler();
            Resumo.UsuarioId =  Usuario_Id;

            resumoRepo.InsertResumo(Resumo);

            resumoRepo.Save();

            return Ok(Resumo);

        } // Fim método


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpPut]
        public HttpResponseMessage PutSingle([FromBody]Resumo Resumo)

        {
      this.SetCurrentLoggedUserHandler();

            Resumo ResumoFromDb = resumoRepo.FindResumoByBothIds(Resumo.Id,  Usuario_Id);

            if (ResumoFromDb != null)
            {
                ResumoFromDb.Atualizado_em = DateTime.Now;
                ResumoFromDb.Conteudo = Resumo.Conteudo;
                resumoRepo.UpdateResumo(ResumoFromDb);
                resumoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , Resumo);
              

            }

         return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

        } // Fim método

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {
      this.SetCurrentLoggedUserHandler();

            Resumo ResumoFromDb = resumoRepo.FindResumoByBothIds(Id,  Usuario_Id);

            if (ResumoFromDb != null)
            {
                resumoRepo.DeleteResumo(ResumoFromDb);
                resumoRepo.Save();

                return Request.CreateResponse(jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }


            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

        }


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    [Authorize(Roles = "Administrador")]
    [HttpPost]
      [HttpOptions]
        public HttpResponseMessage Post([FromBody]Resumo Resumo)
        {

            Resumo ResumoFromDb = resumoRepo.FindResumoByUsuarioId(Resumo.UsuarioId);

            if (ResumoFromDb != null)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

            }

     

            resumoRepo.InsertResumo(Resumo);
            resumoRepo.Save();

            return Request.CreateResponse(HttpStatusCode.OK , Resumo);
        }

       [Authorize (Roles ="Administrador")]
       [HttpPut]
       [HttpOptions]
        public HttpResponseMessage Put([FromBody]Resumo Resumo)
        {

            Resumo ResumoFromDb = resumoRepo.FindResumoByBothIds(Resumo.Id, Resumo.UsuarioId);

            if (ResumoFromDb != null)
            {
        ResumoFromDb.Conteudo = Resumo.Conteudo;
        ResumoFromDb.Atualizado_em = DateTime.Now;
        resumoRepo.UpdateResumo(ResumoFromDb);
                resumoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , Resumo);

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));
   
        }

    [Authorize(Roles = "Administrador")]
    [HttpDelete]
       [HttpOptions]
        public HttpResponseMessage Delete([FromBody]Resumo Resumo)
        {

            Resumo ResumoFromDb = resumoRepo.FindResumoByBothIds(Resumo.Id, Resumo.UsuarioId);

            if (ResumoFromDb != null)
            {
                resumoRepo.DeleteResumo(Resumo);
                resumoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , jsonResultObjHelper.getArquivoJsonResultSuccessObj());
               

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));
        }



    } // Fim da classe
} // Fim da namespace
