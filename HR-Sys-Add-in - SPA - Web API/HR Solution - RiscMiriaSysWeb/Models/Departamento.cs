using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RiscServicesHRSharepointAddIn.Models
{
    public class Departamento : LogableModelTemplate
    {

        public Departamento() : base() {}

        [Key]
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
     

        public int AreaId { get; set; }
        
        public Area Area { get; set; }


    [IgnoreDataMember]
        public ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
    }
}
