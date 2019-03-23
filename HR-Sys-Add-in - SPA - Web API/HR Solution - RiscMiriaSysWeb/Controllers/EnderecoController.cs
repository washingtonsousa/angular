using System;
using RiscServicesHRSharepointAddIn.Filters;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;

namespace RiscServicesHRSharepointAddIn.Controllers
{

  public class EnderecoController : BasicApiAppController
    {
        private EnderecoRepository endRepo;
        private DepartamentoRepository depRepo;
        private JsonResultObjHelper jsonResultObjHelper;
 
        public EnderecoController()
        {
            endRepo = new EnderecoRepository();
            depRepo = new DepartamentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();  
        } // Fim método

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult Get()
        {

          IList<Endereco> Enderecos = endRepo.GetEnderecos();


          return Ok(Enderecos);
        }

        [Authorize(Roles = "Administrador, Funcionario")]
        [HttpGet]
        [HttpOptions]
        public IHttpActionResult GetSingle()
        {
          this.SetCurrentLoggedUserHandler();
          IList<Endereco> Enderecos = endRepo.GetEnderecos().Where(c => c.UsuarioId == Usuario_Id).ToList();

          if (Enderecos.FirstOrDefault() == null)
          {
            return NotFound();
          }

          return Ok(Enderecos);

        }

        [Authorize(Roles = "Administrador, Funcionario")]
        [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage DeleteSingle(int Id)
        {
            this.SetCurrentLoggedUserHandler();

            Endereco enderecoFromDb = endRepo.FindEnderecoByBothIds(Id, Usuario_Id);

            if (enderecoFromDb != null)
            {
                endRepo.DeleteEndereco(enderecoFromDb);
                endRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK ,jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }

           
            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

        }

        [Authorize(Roles = "Administrador, Funcionario")]
        [HttpOptions]
        [HttpPut]
        public HttpResponseMessage PutSingle([FromBody]Endereco Endereco)
        {

            this.SetCurrentLoggedUserHandler();

            Endereco enderecoFromDb = endRepo.FindEndereco(Endereco.Id);

            if (enderecoFromDb.UsuarioId == Usuario_Id && enderecoFromDb != null)
            {
                enderecoFromDb.Atualizado_em = DateTime.Now;
                enderecoFromDb.Bairro = Endereco.Bairro;
                enderecoFromDb.CEP = Endereco.CEP;
                enderecoFromDb.Rua = Endereco.Rua;
                enderecoFromDb.Cidade = Endereco.Cidade;
                enderecoFromDb.Complemento = Endereco.Complemento;
                enderecoFromDb.Numero = Endereco.Numero;
                enderecoFromDb.Referencia = Endereco.Referencia;
                endRepo.UpdateEndereco(enderecoFromDb);
                endRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK , Endereco);
            }




            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));

        }


        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult PostSingle([FromBody]Endereco Endereco)
        {

            this.SetCurrentLoggedUserHandler();

            Endereco.UsuarioId = Usuario_Id;

          
                endRepo.InsertEndereco(Endereco);
                endRepo.Save();

                return Json(Endereco);


        } // Fim método



        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Endereco endereco)
        {

            endRepo.InsertEndereco(endereco);
            
            endRepo.Save();

            return Ok(endereco);

        }


        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {

            Endereco enderecoFromDb = endRepo.FindEndereco(Id);
            if (enderecoFromDb != null)
            {
                endRepo.DeleteEndereco(enderecoFromDb);
                endRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK , jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }
     

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));
        }


        [Authorize(Roles = "Administrador")]
        [HttpOptions]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Endereco endereco)
        {
            Endereco enderecoFromDb = endRepo.FindEndereco(endereco.Id);

            if (enderecoFromDb != null)
            {

                enderecoFromDb.CEP = endereco.CEP;
                enderecoFromDb.Bairro = endereco.Bairro;
                enderecoFromDb.Cidade = endereco.Cidade;
                enderecoFromDb.Complemento = endereco.Complemento;
                enderecoFromDb.Atualizado_em = DateTime.Now;
                enderecoFromDb.Numero = endereco.Numero;
                enderecoFromDb.Referencia = endereco.Referencia;

                endRepo.UpdateEndereco(enderecoFromDb);

                endRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , endereco);
            }


            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseNullResultError()));
        }

    } // Classe

} // Namespace
