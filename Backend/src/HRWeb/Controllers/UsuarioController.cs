using System.Collections.Generic;
using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Description;
using Core.Application.Helpers;
using Core.Application.Strategy.Errors;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class UsuarioController : BasicApiAppController
  {
    IUsuarioAppService _usuarioAppService;

    public UsuarioController(IUsuarioAppService usuarioAppService, IDomainNotificationHandler<DomainNotification> domainNotification) : base(domainNotification)
    {
      _usuarioAppService = usuarioAppService;
    }



    /// <summary>
    /// Retorna busca de usuário pelo Id do mesmo
    /// </summary>
    /// <param name="id">Id do usuário</param>
    /// <returns></returns>
    [Authorize(Roles = "Administrador, Funcionario")]
    [ResponseType(typeof(Usuario))]
    [HttpGet]
    public HttpResponseMessage Get(int id)
    {

      Usuario usuario =  _usuarioAppService.GetUsuarioById(id);
      return ResponseWithNotifications(usuario);

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

      var usuario = _usuarioAppService.InsertUsuario(Usuario);
      return ResponseWithNotifications(usuario);

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
    public  HttpResponseMessage Get()
    {

        var usuarios = _usuarioAppService.GetAll();
        return ResponseWithNotifications(usuarios);

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
    public HttpResponseMessage Put([FromBody]Usuario Usuario)
    {

      Usuario usuarioFromDb = _usuarioAppService.Atualizar(Usuario);
      return ResponseWithNotifications(usuarioFromDb);

    }

    /// <summary>
    ///  Serve para que o próprio usuário mesmo que não tenha acesso possa atualizar dados
    ///  que ele possa atualizar dados os quais ele atualizando não afete a segurança
    /// </summary>
    /// <param name="Usuario"> Usuario a ser atuliazado, mas somente os dados autorizados conforme escopo
    /// do método </param>
    /// <returns> Mensagem de sucesso ou de erro | string | Json </returns>
    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpPut]
    [ResponseType(typeof(Usuario))]
    public HttpResponseMessage PutSecure([FromBody]Usuario Usuario)
    {
      Usuario _usuario = _usuarioAppService.AtualizarParcial(Usuario);
      return ResponseWithNotifications(_usuario);
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
       _usuarioAppService.Delete(id);
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
    public HttpResponseMessage GetByMatricula([FromUri]string matricula)
    {
      Usuario usuario = _usuarioAppService.GetByMatricula(matricula);
      return ResponseWithNotifications(usuario);
    }



  } // Fim da classe
} // Fim da namespace
