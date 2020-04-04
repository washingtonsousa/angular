using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
    public class NivelAcesso : Entity
    {

        public NivelAcesso() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nivel { get; set; }
  
    }
}
