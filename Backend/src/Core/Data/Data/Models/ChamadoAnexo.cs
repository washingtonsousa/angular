using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class ChamadoAnexo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String NomeArquivo { get; set; }

        [Required]
        public String CaminhoArquivo { get; set; }

        [Required]
        public String TipoArquivo { get; set; }

        [Required]
        public String Ext { get; set; }

        [Required]
        public int ChamadoMensagemId { get; set; }

        public ChamadoMensagem ChamadoMensagem { get; set; }
    }
}