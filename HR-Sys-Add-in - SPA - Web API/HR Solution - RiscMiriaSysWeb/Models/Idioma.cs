using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class Idioma : LogableModelTemplate
    {

        public Idioma() : base() { }

        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public String Nome { get; set; }
        [Required]
        public String Fluencia { get; set; }
        [Required]
        public int UsuarioId { get; set; }

       
    }
}