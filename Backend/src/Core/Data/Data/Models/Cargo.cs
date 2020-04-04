using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
    public class Cargo : Entity
    {

        public Cargo() : base() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [IgnoreDataMember]
        public ICollection<Usuario> Usuarios { get; set; }  

        [Required]
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

    }
}
