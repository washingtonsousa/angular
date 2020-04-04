using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Idioma : Entity
    {

        public Idioma() : base() { }

        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Fluencia { get; set; }
        [Required]
        public int UsuarioId { get; set; }

       
    }
}