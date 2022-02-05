using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet2.Models
{
    public class ClienteModel
    {
        [HiddenInput]
        [Display(Name = "Id do Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required]
        [MaxLength(70, ErrorMessage = "O tamanho máximo é 50 caracteres para o Nome!")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de dois caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o campo email")]
        [EmailAddress]
        [Display(Name = "e-Mail")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public String  Observacao { get; set; }

    }
}
