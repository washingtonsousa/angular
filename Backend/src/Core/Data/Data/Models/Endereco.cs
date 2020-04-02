using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
  public class Endereco : LogableModelTemplate
    {
        public Endereco() : base() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public String Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        public String Complemento { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public String Bairro { get; set; }
        [Required]
        public int UsuarioId { get; set; }

        [IgnoreDataMember]
        public Usuario Usuario { get; set; }
        [Required]
        public String Referencia { get; set; }
        [Required]
        public String Cidade { get; set; }

     }
}
