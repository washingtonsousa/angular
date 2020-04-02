using System;
using SP = Microsoft.SharePoint.Client;

namespace Core.Data.Models
{
  public class DesligamentoColaborador
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public SP.FieldUserValue Colaborador { get; set; }
        public DateTime DataPesquisa { get; set; }
        public DateTime DataDesligamento { get; set; }
        public SP.FieldUserValue Entrevistador { get; set; }
        public Double NotaRh { get; set; }
        public Double NotaConsultoria { get; set; }
        public Double NotaAdministrativo { get; set; }
        public Double NotaOperacao { get; set; }
        public string Questao1 { get; set; }
        public Double Questao2 { get; set; }
        public Double Questao3 { get; set; }
        public Double Questao4 { get; set; }
        public Double Questao5 { get; set; }
        public Double Questao6 { get; set; }
        public Double Questao7 { get; set; }
        public Double Questao8 { get; set; }
        public Double Questao9 { get; set; }
        public Double Questao10 { get; set; }
        public Double Questao11 { get; set; }
  
    

    }
}