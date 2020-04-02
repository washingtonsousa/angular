using System.Collections.Generic;
using System.Linq;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Strategy.Errors;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Web.Http.Description;

namespace HRWeb.Controllers
{
  [Authorize(Roles = "Administrador")]
  public class AreaController : BasicApiAppController
    {

        private AreaRepository areaRepo;
        private UsuariosRepository usuarioRepo;
        private DepartamentoRepository depRepo;
        private JsonResultObjHelper jsonResultObjHelper;

        public AreaController()
        {

           
            usuarioRepo = new UsuariosRepository();
            areaRepo = new AreaRepository();
            depRepo = new DepartamentoRepository();
            jsonResultObjHelper = new JsonResultObjHelper();

        }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpOptions]
    [ResponseType(typeof(IList<Area>))]
    public IHttpActionResult Get()
        {
          
            IList<Area> Areas = areaRepo.GetAreas().OrderBy(a => a.Nome).ToList(); 
            return Ok(Areas);

        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public IHttpActionResult Get(int Id)
    {

      Area Area =  areaRepo.GetAreas().Where(a => a.Id == Id).FirstOrDefault();

      if(Area == null)
      {
        return NotFound();
      }

      return Ok(Area);

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="Area"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public HttpResponseMessage Post([FromBody]Area Area)
        {
            Area areafromDb = areaRepo.GetAreas().Where(a => a.Nome == Area.Nome).FirstOrDefault();

            if (areafromDb == null)
            {

                areaRepo.InsertArea(Area);
                areaRepo.Save();


                return Request.CreateResponse(HttpStatusCode.OK, Area);  

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));

        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpDelete]
    [HttpOptions]
    [ResponseType(typeof(object))]
    public HttpResponseMessage Delete(int Id)
        {
            Area Area = areaRepo.FindArea(Id);

            if (Area != null)
            {

                if (depRepo.GetDepartamentos().Where(d => d.AreaId == Area.Id).FirstOrDefault() != null)
                    
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest , new ErrorHelper().getError(new DatabaseEntityError()));
                }

                    areaRepo.DeleteArea(Area);
                    areaRepo.Save();

                    return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());
                
            }


            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));

        }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="Area"></param>
    /// <returns></returns>
    [HttpPut]
    [HttpOptions]
    [ResponseType(typeof(Area))]
    public HttpResponseMessage Put([FromBody]Area Area)
        {
            Area AreaFromDb = areaRepo.FindArea(Area.Id);


            if (areaRepo.GetAreas().Where(a => a.Nome == Area.Nome && a.Id != Area.Id).FirstOrDefault() != null)
            {
                Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseEntityError()));      
            }

            if (AreaFromDb != null)
            {

                AreaFromDb.Nome = Area.Nome;
                AreaFromDb.imgStr = Area.imgStr;
                areaRepo.UpdateArea(AreaFromDb);
                areaRepo.Save();
            return    Request.CreateResponse(HttpStatusCode.OK, AreaFromDb);

            }

         return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));
   
        }
    }
}
