using System;
using Core.Data.Models;
using SP = Microsoft.SharePoint.Client;

namespace Core.Application.Builders
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe de construção do objeto/model Gestor
  /// 
  /// Pode ser chamada em uma factory ou diretamente
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>


  public class DesligamentoGestorBuilder : Builder
    {
        private int ID;
        private String Title;
        private SP.FieldUserValue Colaborador;
        private Double ComprometimentoDedicacao;
        private DateTime DataPesquisa;
        private DateTime DataDesligamento;
        private SP.FieldUserValue Entrevistador;
        private Double Etica;
        private Double FacilidadeRelacionamento;
        private Double Pontualidade;
        private Double QualidadeEntregaveis;
        private Double AgilidadeEficacia;
        private Double FlexibilidadeInovacao;
        private String Questao1;
        private Double Questao2;
        private Double Questao3;
        private Double Questao4;
        private Double Questao5;
        private Double Questao6;
        private Double TempoAtendimentoDemandas;

        public DesligamentoGestorBuilder()
        {

        }

        public void withID(int ID) {

            this.ID = ID;
        }
        public void withQuestao1(String Questao1)
        {

            this.Questao1 = Questao1;
        }

        public void withQuestao2(Double Questao2)
        {

            this.Questao2 = Questao2;
        }

        public void withQuestao3(Double Questao3)
        {

            this.Questao3 = Questao3;
        }

        public void withQuestao4(Double Questao4)
        {

            this.Questao4 = Questao4;
        }

        public void withQuestao5(Double Questao5)
        {

            this.Questao5 = Questao5;
        }

        public void withQuestao6(Double Questao6)
        {

            this.Questao6 = Questao6;
        }

        public void withDataDesligamento(DateTime DataDesligamento) {

            this.DataDesligamento = DataDesligamento;
        }

        public void withDataPesquisa(DateTime DataPesquisa) {

            this.DataPesquisa = DataPesquisa;
        }

        public void withEntrevistador(SP.FieldUserValue Entrevistador) {

            this.Entrevistador = Entrevistador;
        }

        public void withColaborador(SP.FieldUserValue Colaborador)
        {

            this.Colaborador = Colaborador;
        }


        public void withEtica(Double Etica) {

            this.Etica = Etica;

        }

        public void withFacilidadeRelacionamento(Double FacilicidadeRelacionamento) {
            this.FacilidadeRelacionamento = FacilicidadeRelacionamento;
        }

        public void withPontualidade(Double Pontualidade) {
            this.Pontualidade = Pontualidade;
        }

        public void withQualidadeEntregaveis(Double QualidadeEntregaveis) {
            this.QualidadeEntregaveis = QualidadeEntregaveis;
        }

        public void withAgilidadeEficacia(Double AgilidadeEficacia) {
            this.AgilidadeEficacia = AgilidadeEficacia;
                }

        public void withFlexibilidadeInovacao(Double FlexibilidadeInovacao) {
            this.FlexibilidadeInovacao = FlexibilidadeInovacao;
        }

        public void withTempoAtendimentoDemandas(Double TempoAtendimentoDemandas)
        {
            this.TempoAtendimentoDemandas = TempoAtendimentoDemandas;
        }


        public void withComprometimentoDedicacao(Double ComprometimentoDedicacao)
        {
            this.ComprometimentoDedicacao = ComprometimentoDedicacao;
        }


        public void withTitle(String Title) {

            this.Title = Title;

        }


        public override object Build()
        {

            DesligamentoGestor desligamentoGestor = new DesligamentoGestor();
            desligamentoGestor.Questao1 = this.Questao1;
            desligamentoGestor.Questao2 = this.Questao2;
            desligamentoGestor.Questao3 = this.Questao3;
            desligamentoGestor.Questao4 = this.Questao4;
            desligamentoGestor.Questao5 = this.Questao5;
            desligamentoGestor.Questao6 = this.Questao6;
            desligamentoGestor.ID = this.ID;
            desligamentoGestor.FlexibilidadeInovacao = this.FlexibilidadeInovacao;
            desligamentoGestor.FacilidadeRelacionamento = this.FacilidadeRelacionamento;
            desligamentoGestor.Entrevistador = this.Entrevistador;
            desligamentoGestor.Colaborador = this.Colaborador;
            desligamentoGestor.DataPesquisa = this.DataPesquisa;
            desligamentoGestor.DataDesligamento = this.DataDesligamento;
            desligamentoGestor.AgilidadeEficacia = this.AgilidadeEficacia;
            desligamentoGestor.Etica = this.Etica;
            desligamentoGestor.TempoAtendimentoDemandas = this.TempoAtendimentoDemandas;
            desligamentoGestor.Pontualidade = this.Pontualidade;
            desligamentoGestor.QualidadeEntregaveis = this.QualidadeEntregaveis;
            desligamentoGestor.Title = this.Title;
            desligamentoGestor.ComprometimentoDedicacao = this.ComprometimentoDedicacao;
            return desligamentoGestor;
        }
    }
}