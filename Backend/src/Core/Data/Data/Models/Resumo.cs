using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Resumo : Entity
    {

        public Resumo() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Conteudo { get; set; }
       
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}