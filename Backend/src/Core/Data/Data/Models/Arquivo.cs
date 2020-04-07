using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Arquivo : Entity
    {


        public Arquivo() : base() {}

        public Arquivo(DateTime data_Referencia, int usuarioId, string descricao = null)
        {
            Data_Referencia = data_Referencia;
            UsuarioId = usuarioId;
            Descricao = descricao;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public string Ext { get; set; }

        [Required]
        public string Tipo { get; set; }

 
    

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public string URL { get; set; }
        
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public DateTime Data_Referencia { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}