using System;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;
using Core.Data.Models;
using Core.Application.Builders;

namespace Core.Application.Factories
{
  public class DesligamentoColaboradorFactory
    {
 


        public DesligamentoColaborador DesligamentoColaboradorSimplesObjFactory(ListItem listItem) {

            DesligamentoColaboradorBuilder desligamentoColaboradorBuilder = new DesligamentoColaboradorBuilder();


            desligamentoColaboradorBuilder.withDataPesquisa((DateTime)listItem["DataPesquisa"]);
            desligamentoColaboradorBuilder.withDataDesligamento((DateTime)listItem["DataDesligamento"]);
            desligamentoColaboradorBuilder.withNotaRh((Double)listItem["NotaRh"]);
            desligamentoColaboradorBuilder.withNotaConsultoria((Double)listItem["NotaConsultoria"]);
            desligamentoColaboradorBuilder.withNotaAdministrativo((Double)listItem["NotaAdministrativo"]);
            desligamentoColaboradorBuilder.withNotaOperacao((Double)listItem["NotaOperacao"]);
            desligamentoColaboradorBuilder.withID((int)listItem["ID"]);
            desligamentoColaboradorBuilder.withQuestao1((String)listItem["Questao1"]);
            desligamentoColaboradorBuilder.withQuestao2((Double)listItem["Questao2"]);
            desligamentoColaboradorBuilder.withQuestao3((Double)listItem["Questao3"]);
            desligamentoColaboradorBuilder.withQuestao4((Double)listItem["Questao4"]);
            desligamentoColaboradorBuilder.withQuestao5((Double)listItem["Questao5"]);
            desligamentoColaboradorBuilder.withQuestao6((Double)listItem["Questao6"]);
            desligamentoColaboradorBuilder.withQuestao7((Double)listItem["Questao7"]);
            desligamentoColaboradorBuilder.withQuestao8((Double)listItem["Questao8"]);
            desligamentoColaboradorBuilder.withQuestao9((Double)listItem["Questao9"]);
            desligamentoColaboradorBuilder.withQuestao10((Double)listItem["Questao10"]);
            desligamentoColaboradorBuilder.withQuestao11((Double)listItem["Questao11"]);
            desligamentoColaboradorBuilder.withEntrevistador((SP.FieldUserValue)listItem["Entrevistador"]);
            desligamentoColaboradorBuilder.withTitle((String)listItem["Title"]);
            desligamentoColaboradorBuilder.withColaborador((SP.FieldUserValue)listItem["Colaborador"]);
            DesligamentoColaborador desligamentoColaborador = (DesligamentoColaborador) desligamentoColaboradorBuilder.Build();

            return desligamentoColaborador;

        }

    }
}