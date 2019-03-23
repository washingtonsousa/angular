using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Filters;
using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;

namespace RiscServicesHRSharepointAddIn.Controllers
{

    [Authorize(Roles="Administrador")]
    public class StatusController : BasicApiAppController
    {

        private StatusRepository StatusRepo;
        private JsonResultObjHelper jsonResultObjHelper;
        private UsuariosRepository usuarioRepo;


        public StatusController()
        {
 

            jsonResultObjHelper = new JsonResultObjHelper();
            StatusRepo = new StatusRepository();
            usuarioRepo = new UsuariosRepository();


        }

        [HttpGet]
        [HttpOptions]
        public IHttpActionResult Get()
        {
          
            IList<Status> Status = StatusRepo.GetStatus().ToList();


            return Ok(Status);
        }
        [HttpGet]
        [HttpOptions]
        public IHttpActionResult Get(int Id)
        {

          Status Status = StatusRepo.GetStatus().FirstOrDefault();
          return Ok(Status);

        }
        [HttpPost]
        [HttpOptions]
        public HttpResponseMessage Post([FromBody]Status Status)
        {

                if (StatusRepo.GetStatus().Where(s => s.Nome == Status.Nome).FirstOrDefault() == null)
                {

                StatusRepo.InsertStatus(Status);
                StatusRepo.Save();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Criado com sucesso");


                }

      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));


         }
    [HttpDelete]
    [HttpOptions]
    public HttpResponseMessage Delete(int Id)
        {
            Status Status = StatusRepo.FindStatus(Id);



            if (usuarioRepo.GetUsuarios().Where(u => u.StatusId == Id).FirstOrDefault() == null
                && Status.Nome != "ativo" && Status.Nome != "desativado" && Status != null)
            {

                StatusRepo.DeleteStatus(Status);
                StatusRepo.Save();

        return Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }

      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));

        }

    [HttpPut]
    [HttpOptions]
    public HttpResponseMessage Put([FromBody]Status Status)
        {
            Status StatusFromDb = StatusRepo.FindStatus(Status.Id);

            if (StatusFromDb != null && Status.Nome != "ativo" && Status.Nome != "desativado")
            {

                StatusFromDb.Nome = Status.Nome;
                StatusFromDb.Codigo = Status.Codigo;
                StatusRepo.UpdateStatus(StatusFromDb);
                StatusRepo.Save();


        return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Atualizado com sucesso");
               

            }

      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        } // Fim do método

    } //´Classe

} // Namespace
