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
        [Required(ErrorMessage = "Nome do cliente requerido")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo é 70 caracteres para o Nome!")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de dois caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o campo email")]
        [EmailAddress(ErrorMessage = "Digite corretamente o email")]
        [Display(Name = "e-Mail")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento requerida")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public String  Observacao { get; set; }



        public int RepresentanteId { get; set; }
        public RepresentanteModel Representante { get; set; }



    }
}
