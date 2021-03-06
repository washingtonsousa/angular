﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Models
{
  public class ChamadoMensagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Texto {get; set;}

        [Required]
        public int ChamadoId { get; set; }

        public Chamado Chamado { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime DataHoraMensagem { get; set; }


    }
}