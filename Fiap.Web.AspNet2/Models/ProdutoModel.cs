using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet2.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        public String NomeProduto { get; set; }

        //Navigation Property
        public ICollection<ProdutoLojaModel> ProdutosLojas { get; set; }

    }
}
