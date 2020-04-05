using Core.Application.Abstractions;
using Core.Application.Entities;
using Core.Application.Helpers;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using Core.SharedKernel.Specification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace Core.Application
{
    public class ArquivoAppService : AppServiceWithHub<StatisticsHub>, IArquivoAppService
    {

        private IUsuarioAppService _usuarioAppService;
        private IArquivoRepository _arquivoRepo;
        private ILogAppService _logAppService;
        private IApplicationContextManager _applicationContextManager;


        public ArquivoAppService(IArquivoRepository arquivoRepository,
            ILogAppService logAppService,
            IUsuarioAppService usuarioAppService,
            IUnityOfWork unityOfWork,
            IApplicationContextManager applicationContextManager) : base(unityOfWork)
        {
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

            httpResponseMessage.Content = new StreamContent(new FileStream(filepath, FileMode.Open, FileAccess.Read));
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = arqFromDatabase.Nome + "." + arqFromDatabase.Ext;

            return httpResponseMessage;

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

            httpResponseMessage.Content = new StreamContent(new FileStream(filepath, FileMode.Open, FileAccess.Read));
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = arqFromDatabase.Nome + "." + arqFromDatabase.Ext;
            return httpResponseMessage;
        }



        public async Task<HttpResponseMessage> PostByUserId()
        {
            HttpRequestMessage httpRequestMessage = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;

     

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

            MultipartFileData Documento = null;

            try
            {
                await httpRequestMessage.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.InternalServerError);
            }

            var arquivoFromRequest = new ArquivoFromRequest(provider.FileData[0], new Arquivo(DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture), int.Parse(provider.FormData.Get("Usuario_Id"))));
            Documento = provider.FileData[0];


            if (arquivoFromRequest.FileName.Split(".".ToCharArray()).Length == 2 && !System.IO.File.Exists(arquivoFromRequest.FilePath))
            {

                if (ext == "pdf" || ext == "doc" || ext == "docx")
                {

                    File.Move(Documento.LocalFileName, filePath); // Salva Arquivo na pasta

                    Arquivo.Tipo = fileName.Split(".".ToCharArray()).LastOrDefault();
                    Arquivo.URL = filePath;
                    Arquivo.NomeCompleto = newName;
                    Arquivo.Nome = newName.Split(".".ToCharArray()).FirstOrDefault();
                    Arquivo.Ext = fileName.Split(".".ToCharArray()).LastOrDefault();



                            _arquivoRepo.Insert(Arquivo);
                            _unityOfWork.Commit();


                    Usuario usuario = _usuarioAppService.GetUsuarioById(Arquivo.UsuarioId);

                    _logAppService.GenerateArquivoLogAction(Arquivo.Nome);

                    if (!string.IsNullOrEmpty(ConfigData.EmailAccount) && !string.IsNullOrEmpty(ConfigData.EmailPort)
                         && !string.IsNullOrEmpty(ConfigData.EmailSmtpServer) && !string.IsNullOrEmpty(ConfigData.EmailPassword))
                    {

                        EmailHandler _emailHandler = new EmailHandler(config, new MailMessageFactory()
                        .arquivoEnviadoTemplateToMailMessage(usuario, Arquivo, this.contextAppUrl));

                        _emailHandler.addDestinyAddressFromUsuario(usuario);

                        return Request.CreateResponse(HttpStatusCode.OK, _emailHandler.SendMessage());

                    }

                    return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObjEmailNotSent());

                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidExtError()));

            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidPathOrNameError()));

        }


        public async Task<HttpResponseMessage> Post()
        {


            Arquivo Arquivo = new Arquivo();

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

            MultipartFileData Documento = null;

            try
            {
                await HttpContext.Current.Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

            string Matricula = provider.FormData.Get("Matricula");
            string TipoDoc = provider.FormData.Get("TipoDoc");
            string Descricao = provider.FormData.Get("Descricao");
            Documento = provider.FileData.FirstOrDefault();

            Usuario usuarioFromDb = _usuarioAppService.GetByMatricula(Matricula);


            if (usuarioFromDb != null)
            {

                Arquivo.UsuarioId = usuarioFromDb.Id;
                Arquivo.Data_Referencia = DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string UserDirectory = Arquivo.createArquivoDirectoryIfNotExists();

                string fileName = JsonConvert.DeserializeObject<string>(Documento.Headers.ContentDisposition.FileName);

                string ext = fileName.Split(".".ToCharArray()).LastOrDefault();

                var newName = Arquivo.getArquivoFileName(TipoDoc, ext);

                string filePath = Path.Combine(UserDirectory, newName);

                if (fileName.Split(".".ToCharArray()).Length == 2 && !System.IO.File.Exists(filePath))
                {

                    if (ext == "pdf" || ext == "doc" || ext == "docx")
                    {

                        File.Move(Documento.LocalFileName, filePath);
                        Arquivo.Tipo = ext;
                        Arquivo.URL = filePath;
                        Arquivo.NomeCompleto = newName;
                        Arquivo.Nome = newName.Split(".".ToCharArray()).FirstOrDefault();
                        Arquivo.Ext = ext;
                        Arquivo.Descricao = Descricao;
                        _arquivoRepo.Insert(Arquivo);


                        // Use isso para burlar falhas de SQL resiliente em ações massivas
                        _unityOfWork.Commit();

                        _logAppService.GenerateArquivoLogAction(Arquivo.Nome);

                        if (!string.IsNullOrEmpty(ConfigData.EmailAccount)
                                  && !string.IsNullOrEmpty(ConfigData.EmailPort)
                                  && !string.IsNullOrEmpty(ConfigData.EmailSmtpServer)
                                  && !string.IsNullOrEmpty(ConfigData.EmailPassword))
                        {


                            EmailHandler _emailHandler = new EmailHandler(config, new MailMessageFactory()
                           .arquivoEnviadoTemplateToMailMessage(usuarioFromDb, Arquivo, this.contextAppUrl));

                            _emailHandler.addDestinyAddressFromUsuario(usuarioFromDb);

                            return Request.CreateResponse(HttpStatusCode.OK, _emailHandler.SendMessage());

                        }

                        return Request.CreateResponse(HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObjEmailNotSent());

                    }

                    return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidExtError()));
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidPathOrNameError()));

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new UserNotFoundError()));

        }

    }
}
