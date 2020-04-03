using Microsoft.SharePoint.Client;
using System.Collections.Generic;
using System.Linq;
using HRWeb.Factories;
using HRWeb.Helpers;
using Core.Data.Models;
using Core.Data.Repositories;
using HRWeb.Strategy.Errors;
using System.Net.Http;
using HRWeb.Controllers.TemplateControllers;
using System.Web.Http;
using System.Net;
using Microsoft.SharePoint.Client.UserProfiles;
using System.Configuration;

namespace HRWeb.Controllers
{
  /// <summary>
  /// HR Sharepoint Add in
  /// 
  /// Classe de rotas utilizas na instalação do Add In na base de dados e de seus componentes secundários
  /// </summary>

  public class InstallController : BasicApiAppController
    {

        private UsuarioRepository usuarioRepo;
        private CargoRepository cargoRepo;
        private StatusRepository statusRepo;
        private DepartamentoRepository depRepo;
        private StatusFactory statusFactory;
        private DepartamentoFactory depFactory;
        private CargoFactory cargoFactory;
        private NivelAcessoFactory nivelAcessoFactory;
        private UsuarioFactory usuarioFactory;
        private AreaRepository areaRepo;
        private AreaFactory areaFactory;
        private NivelAcessoRepository nivelAcessoRepo;
        private SPListComponentsHelper SPCompHelper;
        private SPListFactory SPListFactory;
        private ListCollection listCollection;
        ;

        public InstallController()
        {

            this.initialize();
        }
        /// <summary>
        /// Inicialização de componentes utilizados no controller
        /// </summary>
        public void initialize()
        {
            
            SPListFactory = new SPListFactory();       
            usuarioRepo = new UsuarioRepository();
            cargoRepo = new CargoRepository();
            statusRepo = new StatusRepository();
            nivelAcessoRepo = new NivelAcessoRepository();
            depRepo = new DepartamentoRepository();
            statusFactory = new StatusFactory();
            depFactory = new DepartamentoFactory();
            cargoFactory = new CargoFactory();
            nivelAcessoFactory = new NivelAcessoFactory();
            usuarioFactory = new UsuarioFactory();
            areaRepo = new AreaRepository();
            areaFactory = new AreaFactory();
            

        }


    /// <summary>
    /// Inativo, servia para criar listas utilizadas em pesquisas antigas, pode ser reaproveitado no futuro, mas no momento está sem uso.
    /// </summary>
    /// <returns>Response HTTP</returns>
    [Authorize(Roles = "Instalador, Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage createBaseLists() {

            ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

            SPCompHelper = new SPListComponentsHelper(clientContext);

                listCollection = SPCompHelper.clientContext.Web.Lists;

                if(SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Colaborador") == false) { 
                  

                        SPListFactory.PesquisaColaboradorListFactory(SPCompHelper);

                    }


                if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Gestor") == false)
                {
                    
                        SPListFactory.PesquisaGestorListFactory(SPCompHelper);

                    }


                if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desempenho") == false)
                {

                    SPListFactory.PesquisaDesempenhoListFactory(SPCompHelper);

                }

            return Request.CreateResponse(HttpStatusCode.OK , "Executado com sucesso, verifique no site de origem se as listas foram criadas");  
        
    }


       

    /// <summary>
    /// Executa primeira instalação dos componentes básicos.
    /// </summary>
    /// <returns>Http Response</returns>
    [Authorize(Roles="Instalador, Administrador")]
    [HttpPost]
    [HttpOptions]
    public HttpResponseMessage ExecutePrimaryInstall()
        {

            if (
                areaRepo.GetAreas().Count == 0 &&
                depRepo.GetDepartamentos().Count == 0 && 
                cargoRepo.GetCargos().Count == 0 &&
                nivelAcessoRepo.GetNivelAcessos().Count == 0  &&
                usuarioRepo.Get().Count == 0)
            {

                //Area padrão
                areaRepo.InsertArea(areaFactory.DefaultAreaInstallObjFactory());
                areaRepo.Save();
                //Departamento padrão
                depRepo.InsertDepartamento(depFactory.DefaultDepartamentoInstallObjFactory(areaRepo.GetAreas().Where(a => a.Nome == "Default").FirstOrDefault().Id));
                depRepo.Save();
                //Cargo padrão
                cargoRepo.InsertCargo(cargoFactory.DefaultCargoInstallObjFactory(depRepo.GetDepartamentos().Where(d => d.Nome == "Default").FirstOrDefault().Id));
                cargoRepo.Save();
                //Status padrões
                statusRepo.InsertStatus(statusFactory.DefaultAtivoStatusFactory());
                statusRepo.InsertStatus(statusFactory.DefaultDesativadoStatusFactory());
                statusRepo.Save();
                //Niveis de acesso padrões

                IList<NivelAcesso> NiveisdeAcesso = nivelAcessoFactory.DefaultNivelAcessoInstallObjFactory();

                foreach (var nivel in NiveisdeAcesso) {
                    nivelAcessoRepo.InsertNivelAcesso(nivel);
                    nivelAcessoRepo.Save();
                }
               


                ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();
                SPPeopleManagerHelper _spPeopleManager = new SPPeopleManagerHelper(clientContext);
                PersonProperties _personProperties = _spPeopleManager.getPersonPropertiesByEmail(ConfigurationManager.AppSettings["InstallEmailAccount"]);



                  if (_spPeopleManager.execQuery() == false) {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new ErrorHelper()
                      .getError(new SPUserNotFoundError()));
                  }

                Usuario novoUsuario = usuarioFactory.UsuarioInstallObjFactory(_personProperties.DisplayName,
                _personProperties.Email, cargoRepo, nivelAcessoRepo, statusRepo);

                usuarioRepo.InsertUsuario(novoUsuario);

                usuarioRepo.Save();

                return Request.CreateResponse(HttpStatusCode.OK , null);

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, new ErrorHelper().getError(new BasicComponentsInstallError()));

        }

      
    } // Fim da classe  
} // Fim da namespace
