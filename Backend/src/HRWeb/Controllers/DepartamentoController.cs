using System.Collections.Generic;
using System.Linq;
using HRWeb.Filters;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Strategy.Errors;
using System.Web.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using System.Net;
using System.Web.Http.Description;

namespace HRWeb.Controllers
{
  [Authorize(Roles = "Administrador")]
  public class DepartamentoController : BasicApiAppController
  {
     
        private DepartamentoRepository departamentoRepo;
        private UsuarioRepository usuarioRepo;
        private CargoRepository cargoRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public DepartamentoController()
        {
            usuarioRepo = new UsuarioRepository();
            departamentoRepo = new DepartamentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();
            cargoRepo = new CargoRepository();
        }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpOptions]
    [HttpGet]
    [ResponseType(typeof(IList<Departamento>))]
    public IHttpActionResult Get()
        {
    
            IList<Departamento> Departamentos = departamentoRepo.GetDepartamentos().OrderBy(d => d.Nome).ToList();
            return Ok(Departamentos);

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult Get(int Id)
        {

          Departamento Departamento = departamentoRepo.GetDepartamentos().Where(d => d.Id == Id).FirstOrDefault();

      if(Departamento == null)
      {
        return NotFound();
      }

          return Ok(Departamento);

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departamento"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpPost]
        public IHttpActionResult Post([FromBody]Departamento departamento)
        {

            departamentoRepo.InsertDepartamento(departamento);
            departamentoRepo.Save();
            return Ok(departamento);
    
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [ResponseType(typeof(object))]
    [HttpOptions]
    [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            Departamento departamento = departamentoRepo.FindDepartamento(Id);



            if (cargoRepo.GetCargos().Where(c => c.DepartamentoId == Id).FirstOrDefault() == null)
            {
                departamentoRepo.DeleteDepartamento(departamento);
                departamentoRepo.Save();

                

                return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="departamento"></param>
    /// <returns></returns>
    [ResponseType(typeof(Departamento))]
    [HttpOptions]
    [HttpPut]
        public HttpResponseMessage Put([FromBody]Departamento departamento)
        {
            Departamento departamentoFromDb = departamentoRepo.FindDepartamento(departamento.Id);

            if (departamentoFromDb != null)
            {

                departamentoFromDb.Nome = departamento.Nome;
                departamentoFromDb.AreaId = departamento.AreaId;
                departamentoRepo.UpdateDepartamento(departamentoFromDb);
                departamentoRepo.Save();
                return Request.CreateResponse(HttpStatusCode.OK , departamentoFromDb);

            }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        }
    } // Fim da classe
} // Fim da namespace
