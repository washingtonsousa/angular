using System;
using Core.Data.Repositories;
using Core.Data.Models;
using System.Web.Http;
using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace HRWeb.Controllers
{
 
    public class ExpProfissionalController : BasicApiAppController
    {

        private ExpProfissionalRepository expRepo;
        ;

        public ExpProfissionalController()
        {
        
            expRepo = new ExpProfissionalRepository();
                   }


    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get()
    {

      IList<ExpProfissional> ExpProfissionais = expRepo.GetExpProfissionais();


      return Ok(ExpProfissionais);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public IHttpActionResult GetSingle()
    {
      this.SetCurrentLoggedUserHandler();
      IList<ExpProfissional> ExpProfissionais = expRepo.GetExpProfissionais().Where(c => c.UsuarioId == Usuario_Id).ToList();

      if (ExpProfissionais.FirstOrDefault() == null)
      {
        return NotFound();
      }

      return Ok(ExpProfissionais);

    }



    [Authorize(Roles = "Administrador, Funcionario")]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostSingle([FromBody]ExpProfissional ExpProfissional)
        {

      this.SetCurrentLoggedUserHandler();
            int UsuarioId =  Usuario_Id;
            ExpProfissional.UsuarioId = UsuarioId;

                expRepo.InsertExpProfissional(ExpProfissional);
                expRepo.Save();

                return Ok(JsonResultObjHelper.getArquivoJsonResultSuccessObj());

          
        }

        [Authorize(Roles = "Administrador, Funcionario")]
        [HttpOptions] 
        [HttpPut]
        public HttpResponseMessage PutSingle([FromBody]ExpProfissional ExpProfissional)
        {
            this.SetCurrentLoggedUserHandler();
         

            ExpProfissional ExpProfissionalFromDb = expRepo.FindExpProfissionalByBothIds(ExpProfissional.Id, Usuario_Id);

            if (ExpProfissionalFromDb != null)
            {
                ExpProfissional.UsuarioId = Usuario_Id;
                ExpProfissionalFromDb.Cargo = ExpProfissional.Cargo;
                ExpProfissionalFromDb.Descricao = ExpProfissional.Descricao;
                ExpProfissionalFromDb.Empresa = ExpProfissional.Empresa;
                ExpProfissionalFromDb.Fim = ExpProfissional.Fim;
                ExpProfissionalFromDb.UltimoSalario = ExpProfissional.UltimoSalario;
                ExpProfissionalFromDb.Inicio = ExpProfissional.Inicio;
                ExpProfissionalFromDb.Atualizado_em = DateTime.Now;
                expRepo.UpdateExpProfissional(ExpProfissionalFromDb);
                expRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK,JsonResultObjHelper.getArquivoJsonResultSuccessObj());;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));;

            
        }


        [Authorize(Roles = "Administrador, Funcionario")]
        [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {
      this.SetCurrentLoggedUserHandler();
            ExpProfissional ExpProfissionalFromDb = expRepo.FindExpProfissionalByBothIds(Id,  Usuario_Id);

            if (ExpProfissionalFromDb != null)
            {


                expRepo.DeleteExpProfissional(ExpProfissionalFromDb);
                expRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK,JsonResultObjHelper.getArquivoJsonResultSuccessObj());;

            }


            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));;

        }


        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]ExpProfissional ExpProfissional)
        {
    
            ExpProfissional ExpProfissionalFromDb = expRepo.FindExpProfissionalByBothIds(ExpProfissional.Id, ExpProfissional.UsuarioId);

            if (ExpProfissionalFromDb != null)
            {
        ExpProfissional.UsuarioId = Usuario_Id;
        ExpProfissionalFromDb.Cargo = ExpProfissional.Cargo;
        ExpProfissionalFromDb.Descricao = ExpProfissional.Descricao;
        ExpProfissionalFromDb.Empresa = ExpProfissional.Empresa;
        ExpProfissionalFromDb.Fim = ExpProfissional.Fim;
        ExpProfissionalFromDb.UltimoSalario = ExpProfissional.UltimoSalario;
        ExpProfissionalFromDb.Inicio = ExpProfissional.Inicio;
        ExpProfissionalFromDb.Atualizado_em = DateTime.Now;
        expRepo.UpdateExpProfissional(ExpProfissionalFromDb);
        expRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, ExpProfissional);;

            }
                return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));;
           
        }

        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ExpProfissional ExpProfissional)
        {

            expRepo.InsertExpProfissional(ExpProfissional);
            expRepo.Save();

            return Request.CreateResponse(HttpStatusCode.OK, ExpProfissional);
        }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {

            ExpProfissional ExpProfissionalFromDb = expRepo.Find(Id);

            if (ExpProfissionalFromDb != null)
            {
                expRepo.DeleteExpProfissional(ExpProfissionalFromDb);
                expRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK,JsonResultObjHelper.getArquivoJsonResultSuccessObj());;
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));;


        }



    }
}
