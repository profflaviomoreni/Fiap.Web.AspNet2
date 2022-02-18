﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{

    [Table("Cliente")]
    public class ClienteModel
    {


        [Display(Name = "Id do Cliente")]
        [HiddenInput]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        public String Nome { get; set; }

        [Display(Name = "E-mail do Cliente")]
        [EmailAddress]
        [Required]
        public String Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public String Observacao { get; set; }


        public int RepresentanteId { get; set; }
        
        [ForeignKey("RepresentanteId")]
        public RepresentanteModel Representante { get; set; }

    }
}
