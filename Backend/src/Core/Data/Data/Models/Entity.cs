﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Data.Models
{
    public abstract class Entity

    {

        protected Entity()
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