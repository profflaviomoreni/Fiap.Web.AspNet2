using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Fiap.Web.AspNet2.Models
{
    [Table("ProdutoLoja")]
    public class ProdutoLojaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoLojaId { get; set; }

        public int LojaId { get; set; }
        [ForeignKey("LojaId")]
        public LojaModel Loja { get; set; }

        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }


    }
}
