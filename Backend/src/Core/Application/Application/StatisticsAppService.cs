using Core.Application.Abstractions;
using Core.Application.Entities;
using Core.Application.Interfaces;
using Core.Application.Sharepoint.Services;
using Core.Data.Interfaces;
using Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class StatisticsAppService : AppService, IStatisticsAppService
    {

        private IUsuarioRepository _usuarioRepo;
        private ICargoRepository _cargosRepo;
        private IDepartamentoRepository _departamentosRepo;
        private ILog_ActionRepository _logActionRepo;
        private IAreaRepository _areaRepo;
        private ISharepointUsersService _sharepointUsersService;


        public StatisticsAppService(IUnityOfWork unitOfWork, ISharepointUsersService sharepointUsersService, IUsuarioRepository usuarioRepo, ICargoRepository cargosRepo, IDepartamentoRepository departamentosRepo, ILog_ActionRepository logActionRepo, IAreaRepository areaRepo) : base(unitOfWork)
        {
            _usuarioRepo = usuarioRepo;
            _cargosRepo = cargosRepo;
            _departamentosRepo = departamentosRepo;
            _logActionRepo = logActionRepo;
            _areaRepo = areaRepo;
            _sharepointUsersService = sharepointUsersService;
        }

        public object GetUsuarioBasic()
        {
            return new
            {
                Total_Cadastrado = _usuarioRepo.Get().Count,
                Ativos = _usuarioRepo.Get().Where(u => u.Status.Nome == "ativo").ToList().Count,
                Desativados = _usuarioRepo.Get().Where(u => u.Status.Nome == "desativado").ToList().Count
                //UsuariosSharepoint = _sharepointUsersService.Get().Count
            };
        }


        public EntitiesStatistics GetEntidadesBasic()
        {

            return new EntitiesStatistics
            {
                Cargos = _cargosRepo.Get().Count,
                Departamentos = _departamentosRepo.Get().Count,
                Areas = _areaRepo.Get().Count,
            };
        }


        public IList<LogActionStatistics> GetLogActionStatistics(string Year = null, string Month = null, string Day = null)
        {

            var log_Actions = _logActionRepo.Get()
            .GroupBy(l => new { l.Action_Type, Date = l.Data_Acesso.Date })
            .Select(l => new LogActionStatistics { Total = l.Count(), Action_Type = l.Key.Action_Type, Data_Acesso = l.Key.Date });

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

            return log_Actions.ToList();

        }



        public IList<Log_Action> GetLogActionLimitedList(string Year = null, string Month = null, string Day = null)
        {

            IList<Log_Action> log_Actions = _logActionRepo.Get();

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

            return log_Actions.OrderByDescending(l => l.Data_Acesso).ToList();

        }


    }
}
