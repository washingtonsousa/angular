using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Models
{
  public class Chamado
    {

       [Key]
       public int Id { get; set; }

       [Required]
       public String Titulo { get; set; }

       [Required]
       [Column(TypeName = "Text")]
       public String Descricao { get; set; }

       [Required]
       public DateTime DataAbertura { get; set; }
       
       public DateTime DataConclusao { get; set; }

       [Column(TypeName = "Text")]
       public String TextoConclusao { get; set; }

       [Required]
       public String Status { get; set; }

       [Required]
       public int UsuarioId { get; set; }

       ICollection<ChamadoMensagem> ChamadoMensagem { get; set; }

       ICollection<ChamadoCategoria> ChamadoCategoria { get; set; }


    }
}