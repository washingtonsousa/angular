using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class CertCurso : LogableModelTemplate
    {
        public CertCurso() : base() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public String Descricao {get; set;}

    [Required]
    public String Periodo { get; set; }

    [Required]
    public String Instituicao { get; set; }

        public String Certificadora { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
