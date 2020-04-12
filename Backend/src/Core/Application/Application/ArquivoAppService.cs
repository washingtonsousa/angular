using Core.Application.Abstractions;
using Core.Application.Facades;
using Core.Application.Helpers;
using Core.Application.Interfaces;
using Core.Application.Specification;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Core.Application
{
    public class ArquivoAppService : AppServiceWithHub<StatisticsHub>, IArquivoAppService
    {

        private IUsuarioAppService _usuarioAppService;
        private IArquivoRepository _arquivoRepo;
        private ILogAppService _logAppService;
        private IApplicationContextManager _applicationContextManager;
        private IEmailAppService _emailAppService;

        public ArquivoAppService(IArquivoRepository arquivoRepository,
            ILogAppService logAppService,
            IUsuarioAppService usuarioAppService,
            IUnityOfWork unityOfWork,
            IApplicationContextManager applicationContextManager,
            IEmailAppService emailAppService) : base(unityOfWork)
        {
            _emailAppService = emailAppService;
            _usuarioAppService = usuarioAppService;
            _arquivoRepo = arquivoRepository;
            _logAppService = logAppService;
            _applicationContextManager = applicationContextManager;
        }

        public IList<Arquivo> Get()
        {

            IList<Usuario> Usuarios = _usuarioAppService.Get();
            IList<Arquivo> Arquivos = _arquivoRepo.Get();

            _logAppService.GenerateAccessListArquivoLogAction();

            return Arquivos.OrderBy(a => a.Data_Referencia).ToList();

        }


        public IList<Arquivo> GetSingle()
        {
            IList<Arquivo> Arquivos = _arquivoRepo.GetByUsuarioId(_usuarioAppService.GetUsuarioLoggedInId());
            _logAppService.GenerateAccessListArquivoLogAction();
            return Arquivos;
        }


        public void Delete(int Id)
        {

            Arquivo arqFromDatabase = _arquivoRepo.Find(Id);

            if (arqFromDatabase.NotExists())
                return;

            string filepath = arqFromDatabase.getArquivoFileAbsolutePathForDownload();

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            _arquivoRepo.Delete(arqFromDatabase);
            // Use isso para burlar falhas de SQL resiliente em ações massivas
            _unityOfWork.Commit();
            _logAppService.GenerateArquivoLogAction(arqFromDatabase.Nome);

        }

        public HttpResponseMessage DownloadSingle(int Id)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            Arquivo arqFromDatabase = _arquivoRepo.Find(Id);

            if (_usuarioAppService.GetUsuarioLoggedInId() != arqFromDatabase.UsuarioId)
            {
                httpResponseMessage.StatusCode = HttpStatusCode.Forbidden;
                httpResponseMessage.Content = new StringContent("Acesso proibido");
                return httpResponseMessage;
            }

            string filepath = arqFromDatabase.getArquivoFileAbsolutePathForDownload();

            if (!System.IO.File.Exists(filepath))
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Content = new StringContent("Caminho de Arquivo não encontrato");
                return httpResponseMessage;
            }


            _logAppService.GenerateArquivoLogAction(arqFromDatabase.Nome);

            return ResponseFacade.BuildFileResponseMessage(filepath, $@"{arqFromDatabase.Nome}.{arqFromDatabase.Ext}");

        }


        public HttpResponseMessage Download(int Id)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            Arquivo arqFromDatabase = _arquivoRepo.Find(Id);

            string filepath = arqFromDatabase.getArquivoFileAbsolutePathForDownload();

            if (!System.IO.File.Exists(filepath))
            {
                httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                httpResponseMessage.Content = new StringContent("Caminho de Arquivo não encontrato");
                return httpResponseMessage;
            }

            _logAppService.GenerateArquivoLogAction(arqFromDatabase.Nome);

            return ResponseFacade.BuildFileResponseMessage(filepath, $@"{arqFromDatabase.Nome}.{arqFromDatabase.Ext}");
        }



        public async Task SaveFileByUserId()
        {
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

            var provider = await RequestFormDataProviderFacade.BuildFormDataProvider();

            if (provider == null)
                return;

            var arquivoFromRequest = provider.BuildArquivoFromRequest();

            if (!arquivoFromRequest.IsFileFromRequestValid())
                return;

            arquivoFromRequest.SaveToDirectory();

            if (!arquivoFromRequest.FinishedAndOk)
                return;

            _arquivoRepo.Insert(arquivoFromRequest.Arquivo);
            _unityOfWork.Commit();
            _logAppService.GenerateArquivoLogAction(arquivoFromRequest.Arquivo.Nome);

            var usuario = _usuarioAppService.GetUsuarioLoggedIn();

            _emailAppService.SendFileUploadedNotificationEmail(arquivoFromRequest.Arquivo, usuario);

        }


        public async Task SaveFileByMatricula()
        {
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
            var provider = await RequestFormDataProviderFacade.BuildFormDataProvider();

            if (provider == null)
                return;

            string Matricula = provider.FormData.Get("Matricula");
            Usuario usuarioFromDb = _usuarioAppService.GetByMatricula(Matricula);

            if (usuarioFromDb.NotExists())
                return;

            var arquivoFromRequest = provider.BuildArquivoFromRequest(usuarioFromDb.Id);

            if (!arquivoFromRequest.IsFileFromRequestValid())
                return;

            arquivoFromRequest.SaveToDirectory();

            if (!arquivoFromRequest.IsFileFromRequestValid())
                return;

            _arquivoRepo.Insert(arquivoFromRequest.Arquivo);
            // Use isso para burlar falhas de SQL resiliente em ações massivas
            _unityOfWork.Commit();

            _logAppService.GenerateArquivoLogAction(arquivoFromRequest.Arquivo.Nome);

            _emailAppService.SendFileUploadedNotificationEmail(arquivoFromRequest.Arquivo, usuarioFromDb);

        }

    }
}
