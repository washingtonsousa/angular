using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class CertCurso : LogableModelTemplate
    {
        public CertCurso() : base() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao {get; set;}

    [Required]
    public string Periodo { get; set; }

    [Required]
    public string Instituicao { get; set; }

        public string Certificadora { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
