using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class Resumo : LogableModelTemplate
    {

        public Resumo() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Conteudo { get; set; }
       
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}