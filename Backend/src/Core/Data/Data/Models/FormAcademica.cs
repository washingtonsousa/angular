using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class FormAcademica : LogableModelTemplate
    {

        public FormAcademica() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Instituicao { get; set; }
        [Required]
        public string Curso { get; set; }
        [Required]
        public string TipoCurso { get; set; }


        public string Situacao {get; set;}

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }



    }
}
