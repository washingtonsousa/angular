using System;
using System.ComponentModel.DataAnnotations;

namespace RiscServicesHRSharepointAddIn.Models
{
  public partial class LogableModelTemplate

    {


        protected LogableModelTemplate()
        {
            this.Atualizado_em = DateTime.Now;
            this.Criado_em = DateTime.Now;
        }    

        [Required]
        public DateTime Criado_em { get; set; }

        [Required]
        public DateTime Atualizado_em { get; set; }


    }
}