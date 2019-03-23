using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class Contato : LogableModelTemplate
    {

        public Contato() : base() { }

        [Key]
        public int Id { get; set; }

        public String Descricao { get; set; }

        [Required]
        public long Fixo { get; set; }

        [Required]
        public long Celular { get; set; }


        public String EmailContato { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [IgnoreDataMember]
        public Usuario Usuario { get; set; }






    }
}
