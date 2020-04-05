using Core.Application.Abstractions;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using System;
using System.Linq;

namespace Core.Application
{
    public class LogAppService : AppServiceWithHub<StatisticsHub>, ILogAppService
    {
        IUsuarioAppService _usuarioAppService;
        private readonly ILog_ActionRepository _logActionRepository;
        private IApplicationContextManager _applicationContextManager;

        public LogAppService(IUnityOfWork unitOfWork, ILog_ActionRepository logActionRepository, IUsuarioAppService usuarioAppService, IApplicationContextManager applicationContextManager) : base(unitOfWork)
        {
            _usuarioAppService = usuarioAppService;
            _logActionRepository = logActionRepository;
            _applicationContextManager = applicationContextManager;
        }


        public  void GenerateArquivoLogAction(string ArquivoNome)
        {

            Usuario usuario = _usuarioAppService.GetUsuarioLoggedIn();
            var context = _applicationContextManager.GetContext();

            var log =  new Log_Action
            {

                Host_Address = context.EnderecoRemoto,
                Matricula_Usuario = usuario.Matricula,
                Data_Acesso = DateTime.Now,
                Action_Type = "Ação de Arquivo",
                Usuario = usuario.Nome,
                Action_Details = " Arquivo afetado:  " + ArquivoNome + " ",
                Action_Dest = context.Rota

            };

            _logActionRepository.Insert(log);
            _unityOfWork.Commit();

            StatisticsHub.updateLog_Action(_logActionRepository.Get().FirstOrDefault());

        }

        public  void GenerateAccessListArquivoLogAction()
        {
            Usuario usuario = _usuarioAppService.GetUsuarioLoggedIn();
            var context = _applicationContextManager.GetContext();

            var log = new Log_Action
            {

                Host_Address = context.EnderecoRemoto,
                Matricula_Usuario = usuario.Matricula,
                Data_Acesso = DateTime.Now,
                Action_Type = "Listagem de arquivos",
                Usuario = usuario.Nome,
                Action_Details = " Acessou lista de arquivos no sistema (Checar rota para mais detalhes)",
                Action_Dest = context.Rota

            };

            _logActionRepository.Insert(log);
            _unityOfWork.Commit();

            StatisticsHub.updateLog_Action(_logActionRepository.GetOrderedByData_Acesso().FirstOrDefault());

        }

    }
}
