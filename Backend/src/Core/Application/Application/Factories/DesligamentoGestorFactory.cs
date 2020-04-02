using System;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;
using Core.Data.Models;
using Core.Application.Builders;

namespace Core.Application.Factories
{
  public class DesligamentoGestorFactory
    {
        public DesligamentoGestorFactory() {

            
        }


        public DesligamentoGestor DesligamentoGestorSimplesObjFactory(ListItem listItem) {

            DesligamentoGestorBuilder desligamentoGestorBuilder = new DesligamentoGestorBuilder();

            desligamentoGestorBuilder.withAgilidadeEficacia((Double)listItem["AgilidadeEficacia"]);
            desligamentoGestorBuilder.withComprometimentoDedicacao((Double)listItem["ComprometimentoDedicacao"]);
            desligamentoGestorBuilder.withDataPesquisa((DateTime)listItem["DataPesquisa"]);
            desligamentoGestorBuilder.withDataDesligamento((DateTime)listItem["DataDesligamento"]);
            desligamentoGestorBuilder.withEntrevistador((SP.FieldUserValue)listItem["Entrevistador"]);
            desligamentoGestorBuilder.withEtica((Double)listItem["Etica"]);
            desligamentoGestorBuilder.withFacilidadeRelacionamento((Double)listItem["FacilidadeRelacionamento"]);
            desligamentoGestorBuilder.withID((int)listItem["ID"]);
            desligamentoGestorBuilder.withPontualidade((Double)listItem["Pontualidade"]);
            desligamentoGestorBuilder.withQualidadeEntregaveis((Double)listItem["QualidadeEntregaveis"]);
            desligamentoGestorBuilder.withFlexibilidadeInovacao((Double)listItem["FlexibilidadeInovacao"]);
            desligamentoGestorBuilder.withQuestao1((String)listItem["Questao1"]);
            desligamentoGestorBuilder.withQuestao2((Double)listItem["Questao2"]);
            desligamentoGestorBuilder.withQuestao3((Double)listItem["Questao3"]);
            desligamentoGestorBuilder.withQuestao4((Double)listItem["Questao4"]);
            desligamentoGestorBuilder.withQuestao5((Double)listItem["Questao5"]);
            desligamentoGestorBuilder.withQuestao6((Double)listItem["Questao6"]);
            desligamentoGestorBuilder.withTempoAtendimentoDemandas((Double)listItem["TempoAtendimentoDemandas"]);
            desligamentoGestorBuilder.withTitle((String)listItem["Title"]);
            desligamentoGestorBuilder.withColaborador((SP.FieldUserValue)listItem["Colaborador"]);





            DesligamentoGestor desligamentoGestor = (DesligamentoGestor) desligamentoGestorBuilder.Build();

            return desligamentoGestor;

        }

    }
}