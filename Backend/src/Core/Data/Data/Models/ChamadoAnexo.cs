using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class ChamadoAnexo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeArquivo { get; set; }

        [Required]
        public string CaminhoArquivo { get; set; }

        [Required]
        public string TipoArquivo { get; set; }

        [Required]
        public string Ext { get; set; }

        [Required]
        public int ChamadoMensagemId { get; set; }

        public ChamadoMensagem ChamadoMensagem { get; set; }
    }
}