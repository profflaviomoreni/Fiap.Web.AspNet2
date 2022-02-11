using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{

    [Table("Cliente")]
    public class ClienteModel
    {

        public ClienteModel() { }

        public ClienteModel(int clienteId, String nome, String email)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
        }

        public ClienteModel(int clienteId, String nome, String email, DateTime dataNacimento, String observacao)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNacimento;
            this.Observacao = observacao;
        }

        public ClienteModel(int clienteId, string nome, string email, DateTime dataNascimento, string observacao, int representanteId) : this(clienteId, nome, email, dataNascimento, observacao)
        {
            RepresentanteId = representanteId;
        }

        public ClienteModel(int clienteId, string nome, string email, DateTime dataNascimento, string observacao, int representanteId, RepresentanteModel representante) : this(clienteId, nome, email, dataNascimento, observacao, representanteId)
        {
            Representante = representante;
        }


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
