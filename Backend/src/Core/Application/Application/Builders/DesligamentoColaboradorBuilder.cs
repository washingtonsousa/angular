using System;
using Core.Data.Models;
using SP = Microsoft.SharePoint.Client;

namespace Core.Application.Builders
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
        private string Title;
        private SP.FieldUserValue Colaborador;
        private DateTime DataPesquisa;
        private DateTime DataDesligamento;
        private SP.FieldUserValue Entrevistador;
        private double NotaRh;
        private double NotaConsultoria;
        private double NotaAdministrativo;
        private double NotaOperacao; 
        private string Questao1;
        private double Questao2;
        private double Questao3;
        private double Questao4;
        private double Questao5;
        private double Questao6;
        private double Questao7;
        private double Questao8;
        private double Questao9;
        private double Questao10;
        private double Questao11;

        public DesligamentoColaboradorBuilder() 
        {

        }

        public void withID(int ID)
        {

            this.ID = ID;
        }
        public void withQuestao1(string Questao1)
        {

            this.Questao1 = Questao1;
        }

        public void withQuestao2(double Questao2)
        {

            this.Questao2 = Questao2;
        }

        public void withQuestao3(double Questao3)
        {

            this.Questao3 = Questao3;
        }

        public void withQuestao4(double Questao4)
        {

            this.Questao4 = Questao4;
        }

        public void withQuestao5(double Questao5)
        {

            this.Questao5 = Questao5;
        }

        public void withQuestao6(double Questao6)
        {

            this.Questao6 = Questao6;
        }

        public void withQuestao7(double Questao7)
        {

            this.Questao7 = Questao7;
        }

        public void withQuestao8(double Questao8)
        {

            this.Questao8 = Questao8;
        }

        public void withQuestao9(double Questao9)
        {

            this.Questao9 = Questao9;
        }

        public void withQuestao10(double Questao10)
        {

            this.Questao10 = Questao10;
        }

        public void withQuestao11(double Questao11)
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


        public void withNotaConsultoria(double NotaConsultoria)
        {

            this.NotaConsultoria = NotaConsultoria;

        }

        public void withNotaRh(double NotaRh)
        {
            this.NotaRh = NotaRh;
        }

        public void withNotaAdministrativo(double NotaAdministrativo)
        {
            this.NotaAdministrativo = NotaAdministrativo;
        }

        public void withNotaOperacao(double NotaOperacao)
        {
            this.NotaOperacao = NotaOperacao;
        }

    

        public void withTitle(string Title)
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