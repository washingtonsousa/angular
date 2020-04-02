using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
  public class Conhecimento : LogableModelTemplate
    {


        public Conhecimento() : base() {}

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        [IgnoreDataMember]
        public virtual  ICollection<UsuarioConhecimento> UsuarioConhecimentos { get; set; }

        public CategoriaConhecimento CategoriaConhecimento { get; set; }

        public int? CategoriaConhecimentoId { get; set; }


    }
}
