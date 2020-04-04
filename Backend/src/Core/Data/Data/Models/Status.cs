using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
    public class Status : Entity
    {

        public Status() : base () { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Codigo { get; set; }

    [IgnoreDataMember]
    public virtual ICollection<Usuario> Usuarios { get; set; } 
    }
}
