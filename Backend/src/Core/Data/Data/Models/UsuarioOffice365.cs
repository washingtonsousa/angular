using System;
using System.Collections.Generic;

namespace Core.Data.Models
{
  public class UsuarioOffice365
    {
        public int UsuarioFromDbId { get; set; }
        public String AccountName { get; set; }
        public String DisplayName { get; set; }
        public String PictureUrl { get; set; }
        public String UserUrl { get; set; }
        public String Email { get; set; }
        public bool Status { get; set; }
        public IDictionary<string , string> personProperties {get; set;}

    }
}