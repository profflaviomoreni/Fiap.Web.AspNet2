using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    [Table("Representante")]
    public class RepresentanteModel
    {

        public RepresentanteModel()
        {

        }

        public RepresentanteModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RepresentanteId")]
        public int RepresentanteId { get; set; }

        [Column("NomeRepresentante")]
        [Required]
        [MaxLength(70)]
        [MinLength(2)]
        [Display(Name = "Nome do Representante")]
        public String NomeRepresentante { get; set; }

        [NotMapped]
        public String Token { get; set; }

    }
}
