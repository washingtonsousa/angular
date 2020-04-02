using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
  public class Area : LogableModelTemplate
    {

        public Area() : base() {



        }

     
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set;}

        public string imgStr { get; set; }


          [IgnoreDataMember]
        public ICollection<Departamento> Departamentos { get; set; }

       



    }
}
