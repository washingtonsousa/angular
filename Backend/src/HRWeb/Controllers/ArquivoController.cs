using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Helpers;
using HRWeb.Strategy.Errors;
using HRWeb.Factories;
using HRWeb.Handlers;
using HRWeb.Controllers.TemplateControllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Hosting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;
using HRWeb.Hubs;


namespace HRWeb.Controllers
{

  public class ArquivoController : BasicApiAppController
  {


    private UsuarioRepository usuarioRepo;
    private ArquivoRepository ArquivoRepo;
    private ArquivosHelper ArquivosHelper;
    ;
    private Log_ActionRepository _logActionRepository;
    private ConfigDataHelper configDataHelper;
    public ArquivoController()
    {

      initializeComponents();
    }


    private void initializeComponents()
    {
      _logActionRepository = new Log_ActionRepository();
      usuarioRepo = new UsuarioRepository();
      ArquivoRepo = new ArquivoRepository();
      ArquivosHelper = new ArquivosHelper();
      
      configDataHelper = new ConfigDataHelper();

    }

    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult Get()
    {

      this.SetCurrentLoggedUserHandler();

      IList<Usuario> Usuarios = usuarioRepo.Get();
      IList<Arquivo> Arquivos = ArquivoRepo.Get();

      _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_AccessListArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress, usuarioRepo.FindUsuario(this.Usuario_Id),
        Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));
      _logActionRepository.Save();

      StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());

      return Ok(Arquivos.OrderBy(a => a.Data_Referencia).ToList());

    }


    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpGet]
    public IHttpActionResult GetSingle()
    {


      this.SetCurrentLoggedUserHandler();

      IList<Arquivo> Arquivos = ArquivoRepo.Get().Where(a => a.UsuarioId == this.Usuario_Id)
        .OrderBy(pair => pair.Data_Referencia).ToList();


      _logActionRepository.InsertLog_Action(Log_ActionFactory.
        Generate_AccessListArquivoLog_Action(Request.GetOwinContext().Request.Uri.Host, usuarioRepo.FindUsuario(this.Usuario_Id),
        Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));

      _logActionRepository.Save();

      StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());

      return Ok(Arquivos.OrderBy(a => a.Data_Referencia).ToList());


    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpDelete]
    public HttpResponseMessage Delete(int Id)
    {
      this.SetCurrentLoggedUserHandler();
      Arquivo arqFromDatabase = ArquivoRepo.Find(Id);


      if (arqFromDatabase != null)
      {
        string filepath = ArquivosHelper.getArquivoFileAbsolutePath(HostingEnvironment.MapPath("~/App_data/Uploads"), arqFromDatabase);

        if (System.IO.File.Exists(filepath))
        {
          System.IO.File.Delete(filepath);
        }

        ArquivoRepo.Delete(arqFromDatabase);

        // Use isso para burlar falhas de SQL resiliente em ações massivas
        ArquivoRepo.Save();

        _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_ArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress,
          usuarioRepo.FindUsuario(Usuario_Id), arqFromDatabase,
          Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));

        _logActionRepository.Save();


        StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());



        return Request.CreateResponse(HttpStatusCode.OK, null);

      }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseNullResultError()));
    }


    [Authorize(Roles = "Funcionario, Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage DownloadSingle(int Id)
    {
      this.SetCurrentLoggedUserHandler();
      HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

      Arquivo arqFromDatabase = ArquivoRepo.Find(Id);

      if (this.Usuario_Id != arqFromDatabase.UsuarioId)
      {
        return Request.CreateResponse(HttpStatusCode.Forbidden, "Acesso não permitido!");
      }

      string filepath = ArquivosHelper.getArquivoFileAbsolutePathForDownload(HostingEnvironment.MapPath("~/App_data/Uploads"), arqFromDatabase);

      if (System.IO.File.Exists(filepath))
      {
        byte[] filedata = System.IO.File.ReadAllBytes(filepath);


        string contentType = MimeMapping.GetMimeMapping(filepath);
        _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_ArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress
          , usuarioRepo.FindUsuario(this.Usuario_Id), arqFromDatabase, Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));
        _logActionRepository.Save();


        StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());


        httpResponseMessage.Content = new StreamContent(new FileStream(filepath, FileMode.Open, FileAccess.Read));
        httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
        httpResponseMessage.Content.Headers.ContentDisposition.FileName = arqFromDatabase.Nome + "." + arqFromDatabase.Ext;
        return httpResponseMessage;

      }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidPathOrNameError()));
    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Download(int Id)
    {
      this.SetCurrentLoggedUserHandler();
      HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

      Arquivo arqFromDatabase = ArquivoRepo.Find(Id);

      string filepath = ArquivosHelper.getArquivoFileAbsolutePathForDownload(HostingEnvironment.MapPath("~/App_data/Uploads"), arqFromDatabase);

      if (System.IO.File.Exists(filepath))
      {
        byte[] filedata = System.IO.File.ReadAllBytes(filepath);


        string contentType = MimeMapping.GetMimeMapping(filepath);
        _logActionRepository.InsertLog_Action(Log_ActionFactory.Generate_ArquivoLog_Action(Request.GetOwinContext().Request.RemoteIpAddress
          , usuarioRepo.FindUsuario(this.Usuario_Id), arqFromDatabase, Request.GetOwinContext().Request.Host.ToString() + Request.GetOwinContext().Request.Path.Value));

        _logActionRepository.Save();



        StatisticsHub.updateLog_Action(_logActionRepository.GetLog_ActionsOrderedByData_Acesso().FirstOrDefault());

        httpResponseMessage.Content = new StreamContent(new FileStream(filepath, FileMode.Open, FileAccess.Read));
        httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
        httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

        httpResponseMessage.Content.Headers.ContentDisposition.FileName = arqFromDatabase.Nome + "." + arqFromDatabase.Ext;
        return httpResponseMessage;

      }

      return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new ArquivoInvalidPathOrNameError()));

    }


    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
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
          ConfigData config = configDataHelper.getConfigDataFromConfigFile();


          if (!string.IsNullOrEmpty(config.EmailAccount) && !string.IsNullOrEmpty(config.EmailPort)
               && !string.IsNullOrEmpty(config.EmailSmtpServer) && !string.IsNullOrEmpty(config.EmailPassword))
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







    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
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

            if (!string.IsNullOrEmpty(config.EmailAccount)
                      && !string.IsNullOrEmpty(config.EmailPort)
                      && !string.IsNullOrEmpty(config.EmailSmtpServer)
                      && !string.IsNullOrEmpty(config.EmailPassword))
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
