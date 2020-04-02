using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class ExpProfissional : LogableModelTemplate
    {

        public ExpProfissional() : base() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Empresa { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public float UltimoSalario { get; set; }
        [Required]
        public DateTime Inicio { get; set; }
        [Required]
        public DateTime Fim { get; set; }
   
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        
    }
}