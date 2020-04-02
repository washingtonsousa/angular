using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class ChamadoCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Template { get; set; }

        [Required]
        public string Nome { get; set; }
      
        public ICollection<Chamado> Chamados { get; set; }

    }
}