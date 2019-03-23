using System.Collections.Generic;
using System.Linq;

using RiscServicesHRSharepointAddIn.Helpers;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using System.Web.Http;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Net.Http;
using System.Net;

namespace RiscServicesHRSharepointAddIn.Controllers
{
    [Authorize (Roles="Administrador")]
    public class CargoController : BasicApiAppController
    {
        private CargoRepository cargoRepo;
        private DepartamentoRepository depRepo;
        private UsuariosRepository usuarioRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public CargoController()
        {
           
            cargoRepo = new CargoRepository();
            usuarioRepo = new UsuariosRepository();
            depRepo = new DepartamentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();
        }

        public IHttpActionResult Get()
        {
         
            IList<Cargo> Cargos = cargoRepo.GetCargos().OrderBy(c => c.Nome).ToList();

            return Ok(Cargos);
        }


        public IHttpActionResult Get(int Id)
        {

          Cargo Cargo = cargoRepo.GetCargos().FirstOrDefault();

      if (Cargo == null)
      {
        return NotFound();
      }

          return Ok(Cargo);
        }





        [HttpPost]
        public IHttpActionResult Post([FromBody]Cargo cargo)
        {
           

            cargoRepo.InsertCargo(cargo);

            cargoRepo.Save();

            return Ok(cargo);

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            Cargo cargo = cargoRepo.FindCargoById(id);

            if (usuarioRepo.GetUsuarios().Where(u => u.CargoId == id).FirstOrDefault() == null) { 

                cargoRepo.DeleteCargo(cargo);
                cargoRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());


            }

            return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseEntityError()));
        }

    [HttpPut]
        public HttpResponseMessage Put(Cargo cargo)
        {
            Cargo cargoFromDb = cargoRepo.FindCargoById(cargo.Id);

            if (cargoFromDb != null)
            {

                cargoFromDb.DepartamentoId = cargo.DepartamentoId;
                cargoFromDb.Nome = cargo.Nome;
                cargoRepo.UpdateCargo(cargoFromDb);

                cargoRepo.Save();

        return Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso");

            }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));
        }
    } // Fim da classe
} // Fim da namespace
