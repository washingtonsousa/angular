using System;
using System.Collections.Generic;
using SP = Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client;
using Core.Application.Helpers;
using System.Collections.Specialized;
using Core.Data.Models;

namespace Core.Application.Factories
{
  public class SPListFactory
    {


        public void PesquisaColaboradorListFactory(SharepointListAppServices SPCompHelper)
        {

            SPCompHelper.setListCreationInfo("Pesquisa - Desligamento - Colaborador", "", (int)ListTemplateType.GenericList);
            SP.List newList = SPCompHelper.getNewList();

            SPCompHelper.ClientContext.Load(newList);

            SPCompHelper.ExecuteRequest();

            SP.List spList = SPCompHelper.ClientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Colaborador");

            SPCompHelper.ClientContext.Load(spList);

            SPCompHelper.ExecuteRequest();

            Field ColaboradorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Colaborador", "Colaborador", "Colaborador"));

            SPCompHelper.ExecuteRequest();


            Field EntrevistadorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Entrevistador", "Entrevistador", "Entrevistador"));

            SPCompHelper.ExecuteRequest();


            Field DataDesligamentoField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLDateTimeField("DataDesligamento", "DataDesligamento", "Data do desligamento"));

            SPCompHelper.ExecuteRequest();


            SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLDateTimeField("DataPesquisa", "DataPesquisa", "Data da pesquisa"));

            SPCompHelper.ExecuteRequest();

            Field field = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLTextField("Questao1", "Questao1", "Motivo"));

            SPCompHelper.ExecuteRequest();

            StringCollection questoesStr = new StringCollection();


            questoesStr.Add("Qual sua opinião sobre o ambiente de trabalho da Risc?");
            questoesStr.Add("Qual a sua visão para a Risc melhorar suas instalações físicas?");
            questoesStr.Add("Como você vê a sua relação com seu ex-gestor, no período em que atuaram juntos?");
            questoesStr.Add("Como foi o seu relacionamento com os ex-colegas de trabalho do seu departamento?");
            questoesStr.Add("Qual nota você daria para os demais departamentos da organização? Por que? ");
            questoesStr.Add("Qual a sua opinião em relação aos nossos canais de comunicação interna?");
            questoesStr.Add("A empresa ofereceu as oportunidades necessárias ao seu desenvolvimento profissional?");
            questoesStr.Add("Suas solicitações de treinamentos foram atendidas? Se não, por que? ");
            questoesStr.Add("Os seus objetivos profissionais estavam alinhados aos objetivos da empresa?");
            questoesStr.Add("Que imagem da Risc você levará ao se desligar de suas atividades ? ");


            IList <QuestaoSPList> Questoes = SPCompHelper.getMultipleQuestionsNumberFieldsCollection(questoesStr, "Questao", 2);

            foreach (var Questao in Questoes)
            {
                Field QuestaoField = SPCompHelper.execXMLField(spList,
                SPCompHelper.getXMLFieldNumberQuestionByModel(Questao));
                SPCompHelper.Update(spList);
                SPCompHelper.ExecuteRequest();

            }

            Field fieldNotaRh = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("NotaRh", "NotaRh", "Nota Rh", 1, 5));
            SPCompHelper.ExecuteRequest();

            Field fieldNotaOperacao = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("NotaOperacao", "NotaOperacao", "Nota Operação", 1, 5));

            SPCompHelper.ExecuteRequest();

            Field fieldNotaAdministrativo = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("NotaAdministrativo", "NotaAdministrativo", "Nota Administrativo", 1, 5));

            SPCompHelper.ExecuteRequest();

            Field fieldNotaConsultoria = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("NotaConsultoria", "NotaConsultoria", "Nota Consultoria", 1, 5));

            SPCompHelper.ExecuteRequest();


        }



        public void PesquisaGestorListFactory(SharepointListAppServices SPCompHelper)
        {

            SPCompHelper.setListCreationInfo("Pesquisa - Desligamento - Gestor", "", (int)ListTemplateType.GenericList);
            SP.List newList = SPCompHelper.getNewList();

            SPCompHelper.ClientContext.Load(newList);

            SPCompHelper.ExecuteRequest();

            SP.List spList = SPCompHelper.ClientContext.Web.Lists.GetByTitle("Pesquisa - Desligamento - Gestor");

            SPCompHelper.ClientContext.Load(spList);

            SPCompHelper.ExecuteRequest();

            Field ColaboradorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Colaborador", "Colaborador", "Colaborador"));

            SPCompHelper.ExecuteRequest();


            Field EntrevistadorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Entrevistador", "Entrevistador", "Entrevistador"));

            SPCompHelper.ExecuteRequest();


            Field DataDesligamentoField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLDateTimeField("DataDesligamento", "DataDesligamento", "Data do desligamento"));

            SPCompHelper.ExecuteRequest();

            Field fieldDataPesquisa =
            SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLDateTimeField("DataPesquisa", "DataPesquisa", "Data da pesquisa"));

            SPCompHelper.ExecuteRequest();

            Field field = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLTextField("Questao1", "Questao1", "Motivo"));

            SPCompHelper.ExecuteRequest();

            StringCollection questoesStr = new StringCollection();

     
            questoesStr.Add("Qual a sua opinião sobre o conhecimento técnico do colaborador?");
            questoesStr.Add("Qual a sua opinião sobre a postura profissional do colaborador?");
            questoesStr.Add("Qual sua opinião referente ao relacionamento do colaborador com sua gestão ?");
            questoesStr.Add("Qual sua opinião quanto ao relacionamento do colaborador e seus demais colegas de trabalho?");
            questoesStr.Add("Qual a sua opinião referente ao colaborador, quanto a qualidade e pontualidade de entregáveis?");

            IList<QuestaoSPList> Questoes = SPCompHelper.getMultipleQuestionsNumberFieldsCollection(questoesStr, "Questao", 2);

            foreach (var Questao in Questoes)
            {
                Field QuestaoField = SPCompHelper.execXMLField(spList,
                SPCompHelper.getXMLFieldNumberQuestionByModel(Questao));
                SPCompHelper.Update(spList);
                SPCompHelper.ExecuteRequest();

            }


            Field FacilicidadeRelacionamento = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("FacilidadeRelacionamento", "FacilicidadeRelacionamento", "Facilicidade de Relacionamento", 1, 5));
            SPCompHelper.ExecuteRequest();

            Field fieldComprometimentoDedicacao = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("ComprometimentoDedicacao", "ComprometimentoDedicacao", "Comprometimento e Dedicação", 1, 5));

            SPCompHelper.ExecuteRequest();

            Field AgilidadeEficacia = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("AgilidadeEficacia", "AgilidadeEficacia", "Agilidade e Eficácia", 1, 5));

            SPCompHelper.ExecuteRequest();

            Field FlexibilidadeInovacao = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("FlexibilidadeInovacao", "FlexibilidadeInovacao", "Flexibilidade e Inovação", 1, 5));

            SPCompHelper.ExecuteRequest();

            Field QualidadeEntregaveis = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLNumberStrictedField("QualidadeEntregaveis", "QualidadeEntregaveis", "Qualidade dos Entregáveis", 1, 5));

            Field TempoAtendimentoDemandas = SPCompHelper.execXMLField(spList,
           SPCompHelper.getXMLNumberStrictedField("TempoAtendimentoDemandas", "TempoAtendimentoDemandas", "Tempo de Atendimento das Demandas", 1, 5));

            Field Etica = SPCompHelper.execXMLField(spList,
                       SPCompHelper.getXMLNumberStrictedField("Etica", "Etica", "Ética", 1, 5));

            Field Pontualidade = SPCompHelper.execXMLField(spList,
                       SPCompHelper.getXMLNumberStrictedField("Pontualidade", "Pontualidade", "Pontualidade", 1, 5));

            SPCompHelper.ExecuteRequest();


        }

        public void PesquisaDesempenhoListFactory(SharepointListAppServices SPCompHelper)
        {

            SPCompHelper.setListCreationInfo("Pesquisa - Desempenho", "", (int)ListTemplateType.GenericList);
            SP.List newList = SPCompHelper.getNewList();

            SPCompHelper.ClientContext.Load(newList);

            SPCompHelper.ExecuteRequest();

            SP.List spList = SPCompHelper.ClientContext.Web.Lists.GetByTitle("Pesquisa - Desempenho");

            SPCompHelper.ClientContext.Load(spList);

            SPCompHelper.ExecuteRequest();

          

            Field ColaboradorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Colaborador", "Colaborador", "Colaborador"));

            SPCompHelper.ExecuteRequest();


            Field EntrevistadorField = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLUserField("Entrevistador", "Entrevistador", "Entrevistador"));

            SPCompHelper.ExecuteRequest();

            Field DataPesquisa = 
            SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLDateTimeField("DataPesquisa", "DataPesquisa", "Data da pesquisa"));

            SPCompHelper.ExecuteRequest();

            StringCollection questoesStr = new StringCollection();

            questoesStr.Add("Trabalho em Equipe");
            questoesStr.Add("Liderança");
            questoesStr.Add("Criatividade");
            questoesStr.Add("Produtividade");
            questoesStr.Add("Pontualidade");
            questoesStr.Add("Pró-atividade");
            questoesStr.Add("Organização");
            questoesStr.Add("Agilidade");
            questoesStr.Add("Escrita/ Comunicação");
            questoesStr.Add("Liderança");
            questoesStr.Add("Capacidade analítica");
            questoesStr.Add("Resolução de problemas");
            questoesStr.Add("Habilidade com as ferramentas de trabalho");
            questoesStr.Add("Organização");
            questoesStr.Add("Especialização");


            IList<QuestaoSPList> Questoes = SPCompHelper.getMultipleQuestionsNumberFieldsCollection(questoesStr, "Questao", 1);

            foreach(var Questao in Questoes)
            {
                Field QuestaoField = SPCompHelper.execXMLField(spList,
                SPCompHelper.getXMLFieldNumberQuestionByModel(Questao));
                SPCompHelper.Update(spList);
                SPCompHelper.ExecuteRequest();

            }

        }


            public void PesquisaClimaSurveyListFactory(SharepointListAppServices SPCompHelper)
        {
            SPCompHelper.setListCreationInfo("Pesquisa de Clima Organizacional "+DateTime.Now.Year, "", (int)SP.ListTemplateType.Survey);

            SP.List newList = SPCompHelper.getNewList();

            SPCompHelper.ClientContext.Load(newList);

            SPCompHelper.ExecuteRequest();

            SP.List spList = SPCompHelper.ClientContext.Web.Lists.GetByTitle("Pesquisa de Clima Organizacional " + DateTime.Now.Year);

            SPCompHelper.ClientContext.Load(spList);

            SPCompHelper.ExecuteRequest();

            StringCollection Choices = new StringCollection();

            StringCollection GridTxts = new StringCollection();

            GridTxts.Add("Baixo");

            GridTxts.Add("Medio");

            GridTxts.Add("Alto");
        
            Choices.Add("Em geral, o seu trabalho é estressante?");

            Choices.Add("Você sabe quais são as expectativas que a empresa tem em relação ao seu trabalho");

            Choices.Add("Você tem autonomia para tomar decisões relacionadas às suas próprias tarefas?");

            Field Pontualidade = SPCompHelper.execXMLField(spList,
            SPCompHelper.getXMLSurveyGridChoiceQuestion("Rotina", "Rotina", "Rotina", GridTxts, Choices));

            SPCompHelper.Update(spList);

            SPCompHelper.ExecuteRequest();

        }
    }
}