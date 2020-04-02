using System;
using SP = Microsoft.SharePoint.Client;

namespace Core.Data.Models
{
  public class DesligamentoGestor
    {




        public int ID { get; set; }
        public String Title { get; set; }
        public SP.FieldUserValue Colaborador { get; set; }
        public Double ComprometimentoDedicacao { get; set; }
        public DateTime DataPesquisa { get; set; }
        public DateTime DataDesligamento { get; set; }
        public SP.FieldUserValue  Entrevistador { get; set; }
        public Double Etica { get; set; }
        public Double FacilidadeRelacionamento { get; set; }
        public Double Pontualidade { get; set; }
        public Double QualidadeEntregaveis { get; set; }
        public Double AgilidadeEficacia { get; set; }
        public Double FlexibilidadeInovacao { get; set; }
        public String Questao1 { get; set; }
        public Double Questao2 { get; set; }
        public Double Questao3 { get; set; }
        public Double Questao4 { get; set; }
        public Double Questao5 { get; set; }
        public Double Questao6 { get; set; }
        public Double TempoAtendimentoDemandas { get; set; }
     
    }
}