using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class Area : LogableModelTemplate
    {

        public Area() : base() {



        }

     
        [Key]
        public int Id { get; set; }

        [Required]
        public String Nome { get; set;}

        public String imgStr { get; set; }


          [IgnoreDataMember]
        public ICollection<Departamento> Departamentos { get; set; }

       



    }
}
