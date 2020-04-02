using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Arquivo : LogableModelTemplate
    {


        public Arquivo() : base() {}

        [Key]
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        public String Descricao { get; set; }

        [Required]
        public String Ext { get; set; }

        [Required]
        public String Tipo { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public String URL { get; set; }

        
        [Required]
        public String NomeCompleto { get; set; }

        [Required]
        public DateTime Data_Referencia { get; set; }
    }
}