using System.Collections.Generic;
using System.Linq;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Strategy.Errors;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net;
using System.Net.Http;

namespace HRWeb.Controllers
{

   
    public class ConhecimentoController : BasicApiAppController
    {

    
      
        private ConhecimentoRepository conhecimentoRepo;
        private UsuarioConhecimentoRepository usuarioConhecimentoRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public ConhecimentoController()
        {

         
            conhecimentoRepo = new ConhecimentoRepository();
            usuarioConhecimentoRepo = new UsuarioConhecimentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();

        }


    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpGet]
    [HttpOptions]
        public IHttpActionResult Get()
        {

            IList<Conhecimento> Conhecimentos = conhecimentoRepo.GetConhecimentos();

            return Ok(Conhecimentos);

        }


    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
        {
            Conhecimento conhecimento = conhecimentoRepo.FindConhecimento(Id);
            IList<UsuarioConhecimento> usuarioConhecimentosByConhecimentoId =
                usuarioConhecimentoRepo.GetUsuarioConhecimentos().Where(u => u.ConhecimentoId == Id).ToList();

         

            if (conhecimento != null)
            {

                foreach (var usuarioConhecimento in usuarioConhecimentosByConhecimentoId)
                {
                    usuarioConhecimentoRepo.DeleteUsuarioConhecimento(usuarioConhecimento);
                    usuarioConhecimentoRepo.Save();
                }
                

                    conhecimentoRepo.DeleteConhecimento(conhecimento);

                    conhecimentoRepo.Save();

                    return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());
                
            }

      return Request.CreateResponse(HttpStatusCode.OK, new ErrorHelper().getError(new DatabaseNullResultError()));

        }
    [Authorize(Roles = "Administrador")]
    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]Conhecimento conhecimento) {

            Conhecimento conhecimentoFromDb = conhecimentoRepo.FindConhecimento(conhecimento.Id);

            if (conhecimentoFromDb != null)
            {
               
                conhecimentoFromDb.Nome = conhecimento.Nome;

                conhecimentoFromDb.CategoriaConhecimentoId = conhecimento.CategoriaConhecimentoId;

                conhecimentoRepo.UpdateConhecimento(conhecimentoFromDb);

                conhecimentoRepo.Save();


                return Request.CreateResponse(HttpStatusCode.OK, conhecimentoRepo.FindConhecimento(conhecimento.Id));

            }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        }


    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Post([FromBody]Conhecimento conhecimento)
        {

            if (conhecimentoRepo.GetConhecimentos().Where(c => c.Nome == conhecimento.Nome).FirstOrDefault() == null)
            {
                conhecimentoRepo.InsertConhecimento(conhecimento);

                conhecimentoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, conhecimento);
            }
            

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));
        }

       
    } // Fim da classe
} // Fim da namespace
