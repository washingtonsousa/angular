using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Data.Models
{
  public class Endereco : Entity
    {
        public Endereco() : base() { }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int UsuarioId { get; set; }

        [IgnoreDataMember]
        public Usuario Usuario { get; set; }
        [Required]
        public string Referencia { get; set; }
        [Required]
        public string Cidade { get; set; }

     }
}
