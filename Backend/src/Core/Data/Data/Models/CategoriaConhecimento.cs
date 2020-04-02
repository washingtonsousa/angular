using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Data.Models
{
  public class CategoriaConhecimento : LogableModelTemplate
  {

    [Key]
    public int Id { get; set;  }

    [Required]
    public string Categoria { get; set; }

    [Required]
    public IList<Conhecimento> Conhecimentos { get; set; }

  }
}
