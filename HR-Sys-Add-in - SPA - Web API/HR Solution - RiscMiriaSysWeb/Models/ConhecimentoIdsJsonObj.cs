using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class ConhecimentoIdsJsonObj
  {
   public int UsuarioId { get; set; }
   public IList<int> ConhecimentoIds { get; set; }
  }
}
