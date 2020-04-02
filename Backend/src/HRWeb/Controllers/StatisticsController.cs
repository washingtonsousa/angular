using Microsoft.SharePoint.Client;
using HRWeb.Controllers.TemplateControllers;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HRWeb.Controllers
{

    public class StatisticsController : BasicApiAppController
  {

    private UsuarioRepository usuarioRepo;
    private CargoRepository cargosRepo;
    private DepartamentoRepository departamentosRepo;
    private Log_ActionRepository logActionRepo;
    private AreaRepository areaRepo;
    
    public StatisticsController()
    {
      usuarioRepo = new UsuarioRepository();
      cargosRepo = new CargoRepository();
      departamentosRepo = new DepartamentoRepository();
      logActionRepo = new Log_ActionRepository();
      areaRepo = new AreaRepository();

      this.spAuthHelper = new BasicAuthHelper();
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult GetUsuarioBasic()
    {

      ClientContext clientContext = TokenHelper.GetClientContextWithAccessToken(this.contextAppUrl, this.spAuthHelper.GetSPAppToken());
      SPUserRepository spUserRepository = new SPUserRepository(clientContext);

      return Ok(new { Total_Cadastrado = usuarioRepo.Get().Count,
        Ativos = usuarioRepo.Get().Where(u => u.Status.Nome == "ativo").ToList().Count,
        Desativados = usuarioRepo.Get().Where(u => u.Status.Nome == "desativado").ToList().Count,
        UsuariosSharepoint = spUserRepository.GetSPUsers().Count
      });
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult GetEntidadesBasic()
    {

      return Ok(new
      {
        Cargos = cargosRepo.GetCargos().Count,
        Departamentos = departamentosRepo.GetDepartamentos().Count,
        Areas = areaRepo.GetAreas().Count,

      });
    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    [Route("api/Statistics/GetLogActionStatistics/{Year?}/{Month?}/{Day?}")]
    public IHttpActionResult GetLogActionStatistics(string Year = null, string Month = null, string Day = null)
    {

        var log_Actions = logActionRepo.GetLog_Actions()
        .GroupBy(l => new { l.Action_Type, Date = l.Data_Acesso.Date })
        .Select(l => new { Total = l.Count(), Action_Type = l.Key.Action_Type, Data_Acesso = l.Key.Date });

      if (Year != null)
      {
        log_Actions =  log_Actions.Where(l => l.Data_Acesso.Year == int.Parse(Year)).ToList();
      }

      if (Month != null)
      {
        log_Actions = log_Actions.Where(l => l.Data_Acesso.Month == int.Parse(Month)).ToList();
      }

      if (Day != null)
      {
        log_Actions = log_Actions.Where(l => l.Data_Acesso.Day == int.Parse(Day)).ToList();
      }

      return Ok(log_Actions);

    }




    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    [Route("api/Statistics/GetLogActionLimitedList/{Year?}/{Month?}/{Day?}")]
    public IHttpActionResult GetLogActionLimitedList(string Year = null, string Month = null, string Day = null)
    {

      IList<Log_Action> log_Actions = logActionRepo.GetLog_Actions();

      if (Year != null)
      {
        log_Actions = log_Actions.Where(l => l.Data_Acesso.Year == int.Parse(Year)).ToList();
      }

      if (Month != null)
      {
        log_Actions = log_Actions.Where(l => l.Data_Acesso.Month == int.Parse(Month)).ToList();
      }

      if (Day != null)
      {
        log_Actions = log_Actions.Where(l => l.Data_Acesso.Day == int.Parse(Day)).ToList();
      }

      return Ok(log_Actions.OrderByDescending(l => l.Data_Acesso).ToList());

    }



  }


}
