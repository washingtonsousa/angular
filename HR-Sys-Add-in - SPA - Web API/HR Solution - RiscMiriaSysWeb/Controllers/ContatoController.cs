using System;
using RiscServicesHRSharepointAddIn.Filters;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;

namespace RiscServicesHRSharepointAddIn.Controllers
{

    public class ContatoController : BasicApiAppController
    {
        private ContatoRepository contatoRepo;   
        private JsonResultObjHelper jsonResultObjHelper;

        public ContatoController()
        {
           
            contatoRepo = new ContatoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();

        } // Fim método


    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [HttpPost]
    public IHttpActionResult Get()
    {

      IList<Contato> contatos = contatoRepo.GetContatos();


      return Ok(contatos);
    }

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
    public IHttpActionResult GetSingle()
    {
      this.SetCurrentLoggedUserHandler();
      IList<Contato> contatos = contatoRepo.GetContatos().Where(c => c.UsuarioId == Usuario_Id).ToList();

      if (contatos.FirstOrDefault() == null)
      {
        return NotFound();
      }

      return Ok(contatos);

    }

    [Authorize(Roles ="Funcionario, Administrador")]
        [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {

            this.SetCurrentLoggedUserHandler();

            Contato Contato = contatoRepo.FindContato(Id);

            if (Contato != null && Contato.UsuarioId == Usuario_Id)
            {
                contatoRepo.DeleteContato(Contato);
                contatoRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK,jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        } // Fim método

    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpPut]
        public HttpResponseMessage PutSingle([FromBody]Contato Contato)
        {

      this.SetCurrentLoggedUserHandler();
      Contato contatoFromDb = contatoRepo.FindContato(Contato.Id);
            
          
            if (contatoFromDb != null && contatoFromDb.UsuarioId == Usuario_Id)
            {
                contatoFromDb.Fixo = Contato.Fixo;
                contatoFromDb.Celular = Contato.Celular;
                contatoFromDb.EmailContato = Contato.EmailContato;
                contatoFromDb.Descricao = Contato.Descricao;
                contatoFromDb.Atualizado_em = DateTime.Now;
                contatoRepo.UpdateContato(contatoFromDb);
                contatoRepo.Save();

               


                return Request.CreateResponse(HttpStatusCode.OK,jsonResultObjHelper.getArquivoJsonResultSuccessObj());

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        } //Fim método

    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostSingle([FromBody]Contato Contato)
        {

            this.SetCurrentLoggedUserHandler();

            Contato.UsuarioId = Usuario_Id;

            contatoRepo.InsertContato(Contato);

            contatoRepo.Save();

            return Ok(Contato);

        }


        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [HttpOptions]
        public IHttpActionResult Post([FromBody]Contato Contato)
        {

         contatoRepo.InsertContato(Contato);
         contatoRepo.Save();
         return Ok(Contato);

        }


        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            Contato Contato = contatoRepo.FindContato(id);
            if(Contato != null)
            {
                contatoRepo.DeleteContato(Contato);
                contatoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK,jsonResultObjHelper.getArquivoJsonResultSuccessObj());

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        }
    [Authorize(Roles = "Administrador")]
    [HttpOptions]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Contato Contato)
        {
            Contato contatoFromDb = contatoRepo.FindContato(Contato.Id);

            if (contatoFromDb != null)
            {
                contatoFromDb.Fixo = Contato.Fixo;
                contatoFromDb.Celular = Contato.Celular;
                contatoFromDb.EmailContato = Contato.EmailContato;
                contatoFromDb.Descricao = Contato.Descricao;
                contatoFromDb.Atualizado_em = DateTime.Now;
                contatoRepo.UpdateContato(contatoFromDb);
                contatoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, Contato);

            } 


            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));




        } // Fim método


    } // Classe

    } // Namespace
