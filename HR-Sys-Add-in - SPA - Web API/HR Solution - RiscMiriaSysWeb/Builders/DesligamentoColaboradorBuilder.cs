using System;
using RiscServicesHRSharepointAddIn.Models;
using SP = Microsoft.SharePoint.Client;

namespace RiscServicesHRSharepointAddIn.Builders
{

  /// <summary>
  /// HR Sharepoint Add-in
  /// 
  /// Classe de construção do objeto/model Desligamento Colaborador
  /// 
  /// Pode ser chamada em uma factory ou diretamente
  /// 
  /// 2018 Risc Services Ltda
  /// </summary>

  public class DesligamentoColaboradorBuilder : Builder 
    {
        private int ID;
        private String Title;
        private SP.FieldUserValue Colaborador;
        private DateTime DataPesquisa;
        private DateTime DataDesligamento;
        private SP.FieldUserValue Entrevistador;
        private Double NotaRh;
        private Double NotaConsultoria;
        private Double NotaAdministrativo;
        private Double NotaOperacao; 
        private String Questao1;
        private Double Questao2;
        private Double Questao3;
        private Double Questao4;
        private Double Questao5;
        private Double Questao6;
        private Double Questao7;
        private Double Questao8;
        private Double Questao9;
        private Double Questao10;
        private Double Questao11;

        public DesligamentoColaboradorBuilder() 
        {

        }

        public void withID(int ID)
        {

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

        public void withQuestao7(Double Questao7)
        {

            this.Questao7 = Questao7;
        }

        public void withQuestao8(Double Questao8)
        {

            this.Questao8 = Questao8;
        }

        public void withQuestao9(Double Questao9)
        {

            this.Questao9 = Questao9;
        }

        public void withQuestao10(Double Questao10)
        {

            this.Questao10 = Questao10;
        }

        public void withQuestao11(Double Questao11)
        {

            this.Questao11 = Questao11;
        }

        public void withDataDesligamento(DateTime DataDesligamento)
        {

            this.DataDesligamento = DataDesligamento;
        }

        public void withDataPesquisa(DateTime DataPesquisa)
        {

            this.DataPesquisa = DataPesquisa;
        }

        public void withEntrevistador(SP.FieldUserValue Entrevistador)
        {

            this.Entrevistador = Entrevistador;
        }

        public void withColaborador(SP.FieldUserValue Colaborador)
        {

            this.Colaborador = Colaborador;
        }


        public void withNotaConsultoria(Double NotaConsultoria)
        {

            this.NotaConsultoria = NotaConsultoria;

        }

        public void withNotaRh(Double NotaRh)
        {
            this.NotaRh = NotaRh;
        }

        public void withNotaAdministrativo(Double NotaAdministrativo)
        {
            this.NotaAdministrativo = NotaAdministrativo;
        }

        public void withNotaOperacao(Double NotaOperacao)
        {
            this.NotaOperacao = NotaOperacao;
        }

    

        public void withTitle(String Title)
        {

            this.Title = Title;

        }


        public override object Build()
        {

            DesligamentoColaborador desligamentoColaborador = new DesligamentoColaborador();
            desligamentoColaborador.Questao1 = this.Questao1;
            desligamentoColaborador.Questao2 = this.Questao2;
            desligamentoColaborador.Questao3 = this.Questao3;
            desligamentoColaborador.Questao4 = this.Questao4;
            desligamentoColaborador.Questao5 = this.Questao5;
            desligamentoColaborador.Questao6 = this.Questao6;
            desligamentoColaborador.Questao7 = this.Questao7;
            desligamentoColaborador.Questao8 = this.Questao8;
            desligamentoColaborador.Questao9 = this.Questao9;
            desligamentoColaborador.Questao10 = this.Questao10;
            desligamentoColaborador.Questao11 = this.Questao11;
            desligamentoColaborador.ID = this.ID;  
            desligamentoColaborador.Entrevistador = this.Entrevistador;
            desligamentoColaborador.Colaborador = this.Colaborador;
            desligamentoColaborador.DataPesquisa = this.DataPesquisa;
            desligamentoColaborador.DataDesligamento = this.DataDesligamento;
            desligamentoColaborador.NotaAdministrativo = this.NotaAdministrativo;
            desligamentoColaborador.NotaConsultoria = this.NotaConsultoria;
            desligamentoColaborador.NotaOperacao = this.NotaOperacao;
            desligamentoColaborador.NotaRh = this.NotaRh;
            desligamentoColaborador.Title = this.Title;

            return desligamentoColaborador;
        }
    }
}