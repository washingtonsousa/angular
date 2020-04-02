using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
  public class Log_Action
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data_Acesso { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Matricula_Usuario { get; set; }
       
        public string Host_Address{ get; set; }

        public string Action_Dest { get; set; }

        public string Action_Type { get; set; }

        public string Action_Details { get; set; }

    }
}