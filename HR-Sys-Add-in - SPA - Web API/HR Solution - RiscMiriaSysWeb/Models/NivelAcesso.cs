using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
    public class NivelAcesso : LogableModelTemplate
    {

        public NivelAcesso() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Nivel { get; set; }
  
    }
}
