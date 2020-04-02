using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Usuario : LogableModelTemplate
    {

        public Usuario() : base() { }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        public string Password { get; set; }
    
        public string Email_Secundario_Notificacao { get; set; }

        [Required]
        public long? Ramal { get; set; }

        [Required]
        public string Sexo { get; set; }
    
        public string Matricula { get; set; }


        public int NivelAcessoId { get; set; }


        public int? StatusId { get; set; }



        public int CargoId { get; set; }

     
      
        public DateTime DataAdmissao { get; set; }
        
        public DateTime DataNasc { get; set; }
    
        public string EstadoCivil { get; set; }

        public virtual Status Status { get; set; }

        public NivelAcesso NivelAcesso { get; set; } 
        
        public Cargo  Cargo { get; set; }

        public Resumo Resumo { get; set; }

        public Endereco Endereco { get; set; }

        public string profileImage64string { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public Nullable<DateTime> Data_Demissao { get; set; }

        /// <summary>
        /// Relacionamentos entre as entidades e os Usuários
        /// </summary>

   
        public ICollection<Contato> Contatos { get; set; } 
        public ICollection<Idioma> Idiomas { get; set; }
        public ICollection<FormAcademica> FormAcademicas { get; set; }
        public ICollection<CertCurso> CertCursos { get; set; }
        public ICollection<ExpProfissional> ExpProfissionais { get; set; }
        public virtual  ICollection<UsuarioConhecimento> UsuarioConhecimentos { get; set; }
        public ICollection<Arquivo> Arquivos { get; set; }


  }
}
