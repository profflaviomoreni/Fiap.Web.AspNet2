using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    [Table("Loja")]
    public class LojaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LojaId { get; set; }

        public String NomeLoja { get; set; }

    }
}
