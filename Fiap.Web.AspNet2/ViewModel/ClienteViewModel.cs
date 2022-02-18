using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class ClienteViewModel
    {

        [Display(Name = "Id do Cliente")]
        [HiddenInput]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        public String Nome { get; set; }

        [Display(Name = "E-mail do Cliente")]
        [EmailAddress]
        [Required]
        public String Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        public String Observacao { get; set; }

        [Display(Name = "Representante")]
        public int RepresentanteId { get; set; }
    }
}
