using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RiscServicesHRSharepointAddIn.Models
{
    public class Cargo : LogableModelTemplate
    {

        public Cargo() : base() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [IgnoreDataMember]
        public ICollection<Usuario> Usuarios { get; set; }  

        [Required]
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

    }
}
