using Core.Application.Abstractions;
using Core.Application.Helpers;
using Core.Application.Interfaces;
using Core.Data.Interfaces;
using Core.Data.Models;
using Core.Hubs;
using Core.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

            this.SetCurrentLoggedUserHandler();
            Arquivo Arquivo = new Arquivo();

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

            MultipartFileData Documento = null;

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }


            Documento = provider.FileData[0];
            Arquivo.UsuarioId = int.Parse(provider.FormData.Get("Usuario_Id"));

            Arquivo.Data_Referencia = DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string fileName = JsonConvert.DeserializeObject<string>(Documento.Headers.ContentDisposition.FileName);

            string UserDirectory = ArquivosHelper.createArquivoDirectoryIfNotExists(HostingEnvironment.MapPath("~/App_data/Uploads"), Arquivo);

            var ext = fileName.Split(".".ToCharArray()).LastOrDefault();

            string newName = fileName.Split(".".ToCharArray()).FirstOrDefault() + "-" + Arquivo.Data_Referencia.Day.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Month.ToString("00")
                    + "-" + Arquivo.Data_Referencia.Year + "." + ext;

            string filePath = Path.Combine(UserDirectory, newName);

            if (fileName.Split(".".ToCharArray()).Length == 2 && !System.IO.File.Exists(filePath))
            {

                if (ext == "pdf" || ext == "doc" || ext == "docx")
                {

                    File.Move(Documento.LocalFileName, filePath); // Salva Arquivo na pasta

                    Arquivo.Tipo = fileName.Split(".".ToCharArray()).LastOrDefault();
                    Arquivo.URL = filePath;
                    Arquivo.NomeCompleto = newName;
                    Arquivo.Nome = newName.Split(".".ToCharArray()).FirstOrDefault();
                    Arquivo.Ext = fileName.Split(".".ToCharArray()).LastOrDefault();



                    using (var transaction = ArquivoRepo.Context.Database.BeginTransaction())
                    {
                        try
                        {
                            ArquivoRepo.Insert(Arquivo);
                            ArquivoRepo.Save();
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            // Não faça nada, é apenas para burlar exceptions de transações problemáticas;
                        }
                    }


                    _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_ArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress
                           , usuarioRepo.FindUsuario(this.Usuario_Id), Arquivo, Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));

                    _logActionRepository.Save();


                    StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());

                    Usuario usuario = usuarioRepo.FindUsuario(Arquivo.UsuarioId);


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

            this.SetCurrentLoggedUserHandler();

            Arquivo Arquivo = new Arquivo();

            var provider = new MultipartFormDataStreamProvider(HttpContext.Current.Server.MapPath("~/App_Data"));

            MultipartFileData Documento = null;

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

            string Matricula = provider.FormData.Get("Matricula");
            string TipoDoc = provider.FormData.Get("TipoDoc");
            string Descricao = provider.FormData.Get("Descricao");
            Documento = provider.FileData.FirstOrDefault();

            Usuario usuarioFromDb = usuarioRepo.Get().Where(u => u.Matricula == Matricula).FirstOrDefault();


            if (usuarioFromDb != null)
            {

                Arquivo.UsuarioId = usuarioFromDb.Id;
                Arquivo.Data_Referencia = DateTime.ParseExact(provider.FormData.Get("Data_Referencia"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string UserDirectory = ArquivosHelper.createArquivoDirectoryIfNotExists(HostingEnvironment.MapPath("~/App_data/Uploads"), Arquivo);

                string fileName = JsonConvert.DeserializeObject<string>(Documento.Headers.ContentDisposition.FileName);




                string ext = fileName.Split(".".ToCharArray()).LastOrDefault();

                var newName = ArquivosHelper.getArquivoFileName(TipoDoc, Arquivo, ext);

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
                        ArquivoRepo.Insert(Arquivo);


                        // Use isso para burlar falhas de SQL resiliente em ações massivas
                        ArquivoRepo.Save();

                        _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_ArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress
                            , usuarioRepo.FindUsuario(this.Usuario_Id), Arquivo, Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext()
                            .Request.Path.Value));

                        _logActionRepository.Save();

                        StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());

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
