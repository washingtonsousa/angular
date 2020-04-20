using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using Core.Shared.Kernel.Interfaces;
using Core.Shared.Kernel.Events;
using Core.Application.Interfaces;

namespace HRWeb.Controllers
{
  /// <summary>
  /// HR Sharepoint Add in
  /// 
  /// Classe de rotas utilizas na instalação do Add In na base de dados e de seus componentes secundários
  /// </summary>

  public class InstallController : BasicApiAppController
  {

    IInstallAppService _installAppService;

    public InstallController(IDomainNotificationHandler<DomainNotification> domainNotification, IInstallAppService installAppService) : base(domainNotification)
    {
      _installAppService = installAppService;
    }





    ///// <summary>
    ///// Inativo, servia para criar listas utilizadas em pesquisas antigas, pode ser reaproveitado no futuro, mas no momento está sem uso.
    ///// </summary>
    ///// <returns>Response HTTP</returns>
    //[Authorize(Roles = "Instalador, Administrador")]
    //[HttpPost]
    //[HttpOptions]
    //public HttpResponseMessage createBaseLists() {

    //        ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

    //        SPCompHelper = new SPListComponentsHelper(clientContext);

    //            listCollection = SPCompHelper.clientContext.Web.Lists;

    //            if(SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Colaborador") == false) { 


    //                    SPListFactory.PesquisaColaboradorListFactory(SPCompHelper);

    //                }


    //            if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Gestor") == false)
    //            {

    //                    SPListFactory.PesquisaGestorListFactory(SPCompHelper);

    //                }


    //            if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desempenho") == false)
    //            {

    //                SPListFactory.PesquisaDesempenhoListFactory(SPCompHelper);

    //            }

    //        return Request.CreateResponse(HttpStatusCode.OK , "Executado com sucesso, verifique no site de origem se as listas foram criadas");  

    //}




    /// <summary>
    /// Executa primeira instalação dos componentes básicos.
    /// </summary>
    /// <returns>Http Response</returns>
    [Authorize(Roles = "Instalador, Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage Execute()
    {
      _installAppService.Execute();
      return ResponseWithNotifications("Instalado com sucesso! ;)");
        
    }


  } // Fim da classe  
} // Fim da namespace
