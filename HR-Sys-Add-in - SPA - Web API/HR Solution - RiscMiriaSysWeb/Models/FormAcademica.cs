using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
  public class FormAcademica : LogableModelTemplate
    {

        public FormAcademica() : base() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public String Instituicao { get; set; }
        [Required]
        public String Curso { get; set; }
        [Required]
        public String TipoCurso { get; set; }


        public String Situacao {get; set;}

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }



    }
}
