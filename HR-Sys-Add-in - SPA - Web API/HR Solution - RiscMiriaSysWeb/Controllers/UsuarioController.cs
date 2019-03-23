using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RiscServicesHRSharepointAddIn.Models;
using RiscServicesHRSharepointAddIn.Repositories;
using RiscServicesHRSharepointAddIn.Helpers;
using Microsoft.SharePoint.Client;
using RiscServicesHRSharepointAddIn.Strategy.Errors;
using System.Threading.Tasks;
using RiscServicesHRSharepointAddIn.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using Microsoft.SharePoint.Client.UserProfiles;
using RiscServicesHRSharepointAddIn.Hubs;
using System.Web.Http.Description;

namespace RiscServicesHRSharepointAddIn.Controllers
{

  public class UsuarioController : BasicApiAppControllerWithHub<UsuariosHub>
  {
    private UsuariosRepository usuarioRepo;
    private SPPeopleManagerHelper SPPeopleManager;
    private JsonResultObjHelper jsonResultObjHelper;
    private DateTimeHelper dateTimeHelper;

    public UsuarioController()
    {

      this.initializeComponents();
    }



    private void initializeComponents()
    {
      usuarioRepo = new UsuariosRepository();
      jsonResultObjHelper = new JsonResultObjHelper();
      dateTimeHelper = new DateTimeHelper();
      this.spAuthHelper = new BasicAuthHelper();

    }

    /// <summary>
    /// Retorna busca de usuário pelo Id do mesmo
    /// </summary>
    /// <param name="id">Id do usuário</param>
    /// <returns></returns>
    [Authorize(Roles = "Administrador, Funcionario")]
    [ResponseType(typeof(Usuario))]
    [HttpGet]
    public IHttpActionResult Get(int id)
    {

      Usuario usuario = usuarioRepo.FindUsuario(id);

      return Ok(usuario);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Usuario">objeto JSON com dados do usuário a ser criado</param>
    /// <returns></returns>
    [Authorize(Roles = "Administrador")]
    [ResponseType(typeof(Usuario))]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]Usuario Usuario)
    {
      IList<Usuario> Usuarios = usuarioRepo.GetUsuarios();

      if (Usuarios.Where(u => u.Email == Usuario.Email).FirstOrDefault() == null
          && Usuarios.Where(u => u.Email != Usuario.Email && u.Matricula == Usuario.Matricula).FirstOrDefault() == null
          )
      {
        ClientContext clientContext = TokenHelper.GetClientContextWithAccessToken(this.contextAppUrl, this.spAuthHelper.GetSPAppToken());
        this.SPPeopleManager = new SPPeopleManagerHelper(clientContext);

        var peopleManager = new PeopleManager(clientContext);


        this.SPPeopleManager.getPersonPropertiesByEmail(Usuario.Email);
        this.SPPeopleManager.execQuery();

        if (this.SPPeopleManager.execQuery() == true)
        {

          usuarioRepo.InsertUsuario(Usuario);
          usuarioRepo.Save();

          Usuario usuarioFromDb = usuarioRepo.FindUsuarioByEmail(Usuario.Email);



          usuarioFromDb.Status.Usuarios = null;
          usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;



          UsuariosHub.newUsuario(usuarioFromDb);


          return Request.CreateResponse(System.Net.HttpStatusCode.OK, usuarioFromDb);
        }

        else
        {

          return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new SPUserNotFoundError()));

        }

      }

      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new DatabaseDuplicatedEntryError()));

    }



    // GET api/documentation
    /// <summary>
    /// Lista todos os usuários cadastrados no sistema
    /// Precisa ter token de administrador
    /// </summary>
    /// <returns> Usuários </returns>
    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [ResponseType(typeof(IList<Usuario>))]
    public async Task<IHttpActionResult> Get()
    {

      using (var context = new HrDbContext())
      {

        var usuarios = await usuarioRepo.GetUsuariosAsync();

        return Ok(usuarios);

      }

    }

    // GET api/documentation
    /// <summary>
    /// Recebe dados de usuário a ser atualizado no sistema
    /// </summary>
    /// <param name="Usuario"> Necessita receber objeto Usuario completo </param>
    /// <returns> Usuario atualizado </returns>
    [ResponseType(typeof(Usuario))]
    [Authorize(Roles = "Administrador")]
    [HttpPut]
    public IHttpActionResult Put([FromBody]Usuario Usuario)
    {
      IList<Usuario> Usuarios = usuarioRepo.GetUsuarios();

      if (Usuarios.FirstOrDefault(u => u.Email == Usuario.Email) != null
          && Usuarios.FirstOrDefault(u => u.Email != Usuario.Email && u.Matricula == Usuario.Matricula) == null)
      {

        Usuario usuarioFromDb = usuarioRepo.FindUsuario(Usuario.Id);

        if (usuarioFromDb != null)
        {

          usuarioFromDb.CargoId = Usuario.CargoId;
          usuarioFromDb.NivelAcessoId = Usuario.NivelAcessoId;
          usuarioFromDb.Nome = Usuario.Nome;
          usuarioFromDb.StatusId = Usuario.StatusId;
          usuarioFromDb.Email = Usuario.Email;
          usuarioFromDb.Matricula = Usuario.Matricula;
          usuarioFromDb.DataAdmissao = Usuario.DataAdmissao;
          usuarioFromDb.DataNasc = Usuario.DataNasc;
          usuarioFromDb.EstadoCivil = Usuario.EstadoCivil;
          usuarioFromDb.Ramal = Usuario.Ramal;
          usuarioFromDb.Sexo = Usuario.Sexo;
          usuarioRepo.Save();


          UsuariosHub.updateUsuario(usuarioFromDb);


          usuarioFromDb.Status.Usuarios = null;
          usuarioFromDb.Cargo.Departamento.Area.Departamentos = null;


          return Ok(usuarioFromDb);

        }
      }

      return BadRequest(new ErrorHelper().getError(new ModelStateGenericError()).ToString());

    }

    /// <summary>
    ///  Serve para que o próprio usuário mesmo que não tenha acesso possa atualizar dados
    ///  que ele possa atualizar dados os quais ele atualizando não afete a segurança
    /// </summary>
    /// <param name="Usuario"> Usuario a ser atuliazado, mas somente os dados autorizados conforme escopo
    /// do método </param>
    /// <returns> Mensagem de sucesso ou de erro | String | Json </returns>
    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpPut]
    [ResponseType(typeof(Usuario))]
    public HttpResponseMessage PutSecure([FromBody]Usuario Usuario)
    {
      Usuario _usuario = usuarioRepo.FindUsuario(Usuario.Id);

      if (_usuario != null)
      {


        _usuario.Email_Secundario_Notificacao = Usuario.Email_Secundario_Notificacao;
        usuarioRepo.Save();

        return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Dado atualizado com sucesso");

      }


      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new ModelStateGenericError()));
    }


    /// <summary>
    /// Serve para deletar o usuário do sistema recursivamente
    /// </summary>
    /// <param name="id"> Id do Usuário a ser deletado  </param>
    /// <returns> Json com mensagem de sucesso </returns>
    [ResponseType(typeof(object))]
    [Authorize(Roles = "Administrador")]
    [HttpDelete]
    public HttpResponseMessage Delete(int id)
    {
      Usuario usuario = usuarioRepo.FindUsuario(id);


      if (usuario != null)
      {
        try
        {


          usuarioRepo.DeleteUsuario(usuario);
          usuarioRepo.Save();


          UsuariosHub.deleteUsuario(usuario);
          return Request.CreateResponse(System.Net.HttpStatusCode.OK, jsonResultObjHelper.getArquivoJsonResultSuccessObj());


        }
        catch (DbUpdateException e)
        {

          Error error = new ErrorHelper().getError(new DatabaseEntityError());
          error.detailedMessage = e.InnerException.Message;
          return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, error);

        }
      }

      return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper().getError(new UserNotFoundError()).message);

    }

    /// <summary>
    /// Consulta o usuário pelo número de matrícula
    /// </summary>
    /// <param name="matricula"> código da matrícula do usuário </param>
    /// <returns>Usuário consultado se encontrado</returns>
    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [ResponseType(typeof(Usuario))]
    [Route("api/Usuario/GetByMatricula/{matricula}")]
    public async Task<IHttpActionResult> GetByMatricula([FromUri]string matricula)
    {
      Usuario usuario = await new HrDbContext().Usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);

      return Ok(usuario);


    }



  } // Fim da classe
} // Fim da namespace
