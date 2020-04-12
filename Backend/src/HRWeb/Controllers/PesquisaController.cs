//using Microsoft.SharePoint.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using HRWeb.Helpers;
//using SP = Microsoft.SharePoint.Client;
//using Core.Data.Models;
//using Core.Data.Repositories;
//using HRWeb.Factories;
//using System.Globalization;
//using HRWeb.Strategy.Errors;
//using HRWeb.Controllers.TemplateControllers;
//using System.Net.Http;
//using System.Net;
//using System.Web.Http;

//namespace HRWeb.Controllers
//{

//    [Authorize(Roles = "Administrador")]
//    public class PesquisaController : BasicApiAppController
//    {
//        private SPListComponentsHelper SPCompHelper;
//        private UsuarioRepository usuarioRepo;
//        private DepartamentoRepository depRepo;
//        private CargoRepository cargoRepo;
//        private PaginateHelper pgHelper;


//        public PesquisaController() {


//            initializeComponents();

//        }

//        private void initializeComponents()
//        {
        
//            usuarioRepo = new UsuarioRepository();
//            depRepo = new DepartamentoRepository();
//            cargoRepo = new CargoRepository();
//            pgHelper = new PaginateHelper();

//        }

//        /// <summary>
//        /// Método que realiza consulta na lista Sharepoint com dados de pesquisas de desligamento preenchidas por colaboradores
//        /// que solicitaram o desligamento da empresa
//        /// 
//        /// 
//        /// Versão 0.9
//        /// </summary>
    
//        public HttpResponseMessage GetDesligamentoColaborador()
//        {


//      ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

//      SPCompHelper = new SPListComponentsHelper(clientContext);
          
//                SP.ListCollection listCollection = SPCompHelper.clientContext.Web.Lists;

//            if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Colaborador")
//                == false)
//            {

//            return  Request.CreateResponse(HttpStatusCode.NotFound ,new ErrorHelper().getError(new SPListNotFoundError()));
             
//            }
                 
//                        SP.List spList = SPCompHelper.clientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Colaborador");
//                        SPCompHelper.clientContext.Load(spList);
//                        SPCompHelper.Save();

//                            Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
//                            camlQuery.ViewXml =
//                               @"<View> 
//                                <Query> 
//                                <OrderBy><FieldRef Name='DataPesquisa' /></OrderBy> 
//                                </Query> 
//                                <ViewFields><FieldRef Name='LinkTitle' /><FieldRef Name='Colaborador' />
//                                <FieldRef Name='DataPesquisa' /> <FieldRef Name='DataDesligamento' />
//                                <FieldRef Name='Entrevistador' /> <FieldRef Name='ID' />
//                                <FieldRef Name='NotaAdministrativo' /> <FieldRef Name='NotaConsultoria' />
//                                <FieldRef Name='NotaOperacao' /> <FieldRef Name='NotaRh' />
//                                <FieldRef Name='Questao1' /> <FieldRef Name='Questao10' />
//                                <FieldRef Name='Questao11' /> <FieldRef Name='Questao2' />
//                                <FieldRef Name='Questao3' /> <FieldRef Name='Questao4' />
//                                <FieldRef Name='Questao5' />  <FieldRef Name='Questao6' />
//                                <FieldRef Name='Questao7' /> <FieldRef Name='Questao8' />
//                                <FieldRef Name='Questao9' /> </ViewFields> 
//                               </View>";

//                            ListItemCollection listItems = spList.GetItems(camlQuery);
//                            SPCompHelper.clientContext.Load(listItems);
//                            SPCompHelper.Save();

//                            IList<DesligamentoColaborador> pesquisaDesligamento = new List<DesligamentoColaborador>();

//                            foreach (ListItem listItem in listItems)
//                            {
//                                DesligamentoColaborador desligamentoColaborador
//                                    = new DesligamentoColaboradorFactory().DesligamentoColaboradorSimplesObjFactory(listItem);
//                                pesquisaDesligamento.Add(desligamentoColaborador);

//                            }


//                            Double totalSetores = pesquisaDesligamento.Sum(pesquisa => pesquisa.NotaRh + pesquisa.NotaConsultoria + 
//                            pesquisa.NotaAdministrativo + pesquisa.NotaOperacao) / 4;
//                            Double totalSatisfacao = pesquisaDesligamento.Sum(pesquisa => pesquisa.Questao2 + pesquisa.Questao3 +
//                                pesquisa.Questao4 + pesquisa.Questao5 + pesquisa.Questao6 + pesquisa.Questao7 +
//                                pesquisa.Questao8 + pesquisa.Questao9 + pesquisa.Questao10 + pesquisa.Questao11) / 10;

//      return Request.CreateResponse(HttpStatusCode.OK, new Dictionary<string, double>
//      {
//        ["Financeiro"] = pesquisaDesligamento.Where(p => p.Questao1 == "Financeiro").Count(),
//        ["Desenvolvimento"] = pesquisaDesligamento
//          .Where(p => p.Questao1 == "Desenvolvimento profissional").Count(),
//        ["Relacionamento"] = pesquisaDesligamento.Where(p => p.Questao1 == "Relationamento").Count(),
//        ["Gestao"] = pesquisaDesligamento.Where(p => p.Questao1 == "Gestão").Count(),
//        ["Outros"] = pesquisaDesligamento.Where(p => p.Questao1 == "Outros").Count(),
//        ["TotalSetores"] = totalSetores,
//        ["TotalSatisfacao"] = totalSatisfacao
//      });

 

//        }
   
//        /////////////////////////////////////////////////////////////////////////////////////////////////
      
//            /// <summary>
//            /// Método para exibir os dados de pesquisa preenchida pelo colaborador
//            /// 
//            /// Versão 0.9
//            /// 
//            /// </summary>

     
//        public HttpResponseMessage GetDesligamentoColaboradorSingle(int id) {

//      ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

//      SPCompHelper = new SPListComponentsHelper(clientContext);

//      SP.ListCollection listCollection = SPCompHelper.clientContext.Web.Lists;

//            if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Colaborador")
//                == false)
//            {
//        return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPListNotFoundError()));
//      }

//                        SP.List spList = SPCompHelper.clientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Colaborador");
//                        SPCompHelper.clientContext.Load(spList);
//                        SPCompHelper.Save();


//                            ListItem listItem = spList.GetItemById(id);

//                            SPCompHelper.clientContext.Load(listItem);

//                            SPCompHelper.clientContext.ExecuteQuery();

//                            DesligamentoColaborador desligamentoColaborador
//                                = new DesligamentoColaboradorFactory().DesligamentoColaboradorSimplesObjFactory(listItem);


//                            Double totalQuestoes = (
//                                desligamentoColaborador.Questao2 + desligamentoColaborador.Questao3 +
//                                desligamentoColaborador.Questao4 + desligamentoColaborador.Questao5 +
//                                desligamentoColaborador.Questao6 + desligamentoColaborador.Questao7 +
//                                desligamentoColaborador.Questao8 + desligamentoColaborador.Questao9 +
//                                desligamentoColaborador.Questao10 + desligamentoColaborador.Questao11);

//                            Double totalSetores = (desligamentoColaborador.NotaRh + desligamentoColaborador.NotaConsultoria +
//                            desligamentoColaborador.NotaAdministrativo + desligamentoColaborador.NotaOperacao);

//      return Request.CreateResponse(HttpStatusCode.OK, new
//      {

//        DesligamentoColaborador = desligamentoColaborador,
//        TotalQuestoes = totalQuestoes,
//        TotalSetores = totalSetores

//      });

//        }

//        /// <summary>
//        /// Método que realiza consulta na lista Sharepoint com dados de pesquisas de desligamento preenchidas por gestores
//        /// que solicitaram o desligamento da empresa
//        /// 
//        /// Este método é grande devido o número de funcionalidades empregadas nesta consulta
//        /// 
//        /// Versão 0.9
//        /// </summary>
       
//        public HttpResponseMessage DesligamentoGestorIndex()
//        {

//      ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

//      SPCompHelper = new SPListComponentsHelper(clientContext);

//      SP.ListCollection listCollection = SPCompHelper.clientContext.Web.Lists;

//            if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Gestor")
//                == false)
//            {
//              return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPListNotFoundError()));
//            }  
//                        SP.List spList = SPCompHelper.clientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Gestor");
//                        SPCompHelper.clientContext.Load(spList);
//                        SPCompHelper.Save();
                
//                            Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
//                            camlQuery.ViewXml =
//                            @"<View> 
//                            <Query> 
//                            <OrderBy><FieldRef Name='DataPesquisa' /></OrderBy> 
//                            </Query> 
//                            <ViewFields><FieldRef Name='LinkTitle' /><FieldRef Name='Colaborador' />
//                            <FieldRef Name='ComprometimentoDedicacao' /> <FieldRef Name='DataPesquisa' />
//                            <FieldRef Name='DataDesligamento' /> <FieldRef Name='Entrevistador' />
//                            <FieldRef Name='Etica' /> <FieldRef Name='FacilidadeRelacionamento' /><FieldRef Name='ID' />
//                            <FieldRef Name='Pontualidade' /> <FieldRef Name='QualidadeEntregaveis' />
//                            <FieldRef Name='AgilidadeEficacia' /> <FieldRef Name='FlexibilidadeInovacao' />
//                            <FieldRef Name='Questao1' /> <FieldRef Name='Questao2' />
//                            <FieldRef Name='Questao3' /> <FieldRef Name='Questao4' />
//                            <FieldRef Name='Questao5' /> <FieldRef Name='Questao6' />
//                            <FieldRef Name='TempoAtendimentoDemandas' /></ViewFields> 
//                            </View>";


//                            ListItemCollection listItems = spList.GetItems(camlQuery);
//                            clientContext.Load(listItems);
//                            clientContext.ExecuteQuery();

//                            IList<DesligamentoGestor> pesquisaDesligamento = new List<DesligamentoGestor>();

//                            foreach (ListItem listItem in listItems) {

//                                DesligamentoGestor desligamentoGestor 
//                                    = new DesligamentoGestorFactory().DesligamentoGestorSimplesObjFactory(listItem);
//                                pesquisaDesligamento.Add(desligamentoGestor);

//                            }

//                            Double totalValores = pesquisaDesligamento.Sum(pesquisa => pesquisa.Pontualidade +
//                                pesquisa.QualidadeEntregaveis + pesquisa.TempoAtendimentoDemandas +
//                                pesquisa.AgilidadeEficacia + pesquisa.ComprometimentoDedicacao +
//                                pesquisa.FacilidadeRelacionamento + pesquisa.FlexibilidadeInovacao +
//                                pesquisa.Etica + pesquisa.Pontualidade) / 9;


//                            Double totalSatisfação = pesquisaDesligamento.Sum( pesquisa =>
//                                pesquisa.Questao2 + pesquisa.Questao3 + pesquisa.Questao4 +
//                                pesquisa.Questao5 + pesquisa.Questao6) / 5;



//                   return Request.CreateResponse(HttpStatusCode.OK , new Dictionary<string, Double>
//                    {
//                      ["Comportamental"] = pesquisaDesligamento.Where(p => p.Questao1 == "Comportamental").Count(),
//                      ["Relacionamento"] = pesquisaDesligamento.Where(p => p.Questao1 == "Relacionamento").Count(),
//                      ["Falta de Conhecimento"] = pesquisaDesligamento.Where(p => p.Questao1 == "Falta de Conhecimento").Count(),
//                      ["Top/Down"] = pesquisaDesligamento.Where(p => p.Questao1 == "Top/Down").Count(),
//                      ["Outros"] = pesquisaDesligamento.Where(p => p.Questao1 == "Outros").Count(),
//                      ["TotalValores"] = totalValores,
//                      ["TotalSatisfacao"] = totalSatisfação
//                   });

//        }


//        /// <summary>
//        /// Método para exibir os dados de pesquisa preenchida pelo Gestor
//        /// 
//        /// Versão 0.9
//        /// 
//        /// </summary>

  
//        public HttpResponseMessage DesligamentoGestorSingle(int id)
//        {

//      ClientContext clientContext = new BasicAuthHelper().getAppOnlyClientContextByToken();

//      SPCompHelper = new SPListComponentsHelper(clientContext);

//      SP.ListCollection listCollection = SPCompHelper.clientContext.Web.Lists;

//      if (SPCompHelper.checkIfListExists(listCollection, "Pesquisa - Desligamento - Gestor")
//      == false)
//      {
//        return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorHelper().getError(new SPListNotFoundError()));
//      }

//      SP.List spList = clientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Gestor");
//                clientContext.Load(spList);
//                clientContext.ExecuteQuery();

//                ListItem listItem = spList.GetItemById(id);
//                clientContext.Load(listItem);
//                clientContext.ExecuteQuery();

//                DesligamentoGestor desligamentoGestor
//                    = new DesligamentoGestorFactory().DesligamentoGestorSimplesObjFactory(listItem);


//                Double totalQuestoes = ( desligamentoGestor.Questao2 + desligamentoGestor.Questao3 +
//                    desligamentoGestor.Questao4 + desligamentoGestor.Questao5 +
//                    desligamentoGestor.Questao6) / 5;

//                Double totalValores = ( desligamentoGestor.FacilidadeRelacionamento +
//                desligamentoGestor.ComprometimentoDedicacao + desligamentoGestor.FlexibilidadeInovacao +
//                desligamentoGestor.AgilidadeEficacia + desligamentoGestor.QualidadeEntregaveis +
//                desligamentoGestor.TempoAtendimentoDemandas + desligamentoGestor.Etica +
//                desligamentoGestor.Pontualidade ) / 8;


//            return Request.CreateResponse(HttpStatusCode.OK, new { DesligamentoGestor = desligamentoGestor, TotalQuestoes = totalQuestoes, TotalValores = totalValores });

//        } // Fim do método

//    } // Fim da classe

//} // Fim da namespace
