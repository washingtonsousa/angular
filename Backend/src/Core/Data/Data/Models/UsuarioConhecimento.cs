using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class UsuarioConhecimento : LogableModelTemplate
    {

        public UsuarioConhecimento() : base() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public virtual  Usuario Usuario { get; set; } 

        [Required]
        public int ConhecimentoId { get; set; }

        public virtual  Conhecimento Conhecimento { get; set; }


    }
}
