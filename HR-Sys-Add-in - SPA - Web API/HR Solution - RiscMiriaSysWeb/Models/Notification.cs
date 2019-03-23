using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class Notification
  {

    [Key]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    public string Descricao { get; set; }

    [Required]
    public string referenceLink { get; set; }

    public Usuario Usuario { get; set; }

    [Required]
    public int UsuarioId { get; set; }

    public bool? vizualizada { get; set; }

    public DateTime dataNotificacao { get; set; }

  }
}
