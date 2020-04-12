using Core.Data.Models;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net.Http;
using Core.Application.Interfaces;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;

namespace HRWeb.Controllers
{

  public class UsuarioConhecimentoController : BasicApiAppController
  {

    private IUsuarioAppService _usuarioAppService;

    public UsuarioConhecimentoController(IDomainNotificationHandler<DomainNotification> domainNotification, IUsuarioAppService usuarioAppService) : base(domainNotification)
    {
      _usuarioAppService = usuarioAppService;
    }

    /* 
     * @UpdateAction
     * @Método insere ou deleta entradas na entidade UsuarioConhecimento com base no parametro recebido
     * @Param IList<int> ConhecimentoIds = List de Ids de conhecimentos para serem deletados ou inseridos 
     * na entidade associada UsuarioConhecimento relacionada a 'Usuario ManyToMany Conhecimento'
     * */

    [Authorize(Roles = "Administrador, Funcionario")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage PostSingle([FromBody]ConhecimentoIdsJsonObj ConhecimentoIds)
    {

      _usuarioAppService.AddConhecimentosForUsuarioLoggedIn(ConhecimentoIds.ConhecimentoIds);
      return ResponseWithNotifications();


    } // Método @UpdateAction



    [Authorize(Roles = "Administrador")]
    [HttpOptions]
    [HttpPost]
    public HttpResponseMessage Post([FromBody]ConhecimentoIdsJsonObj ConhecimentoIds)
    {


      _usuarioAppService.AddConhecimentosForUsuarioByUsuarioId(ConhecimentoIds.ConhecimentoIds, ConhecimentoIds.UsuarioId);
      return ResponseWithNotifications();


    } // Método @UpdateAction

  } // classe

} // namespace
