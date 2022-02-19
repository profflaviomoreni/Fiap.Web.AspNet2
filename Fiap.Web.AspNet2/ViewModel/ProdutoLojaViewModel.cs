using System;
using System.Collections.Generic;


namespace Fiap.Web.AspNet2.ViewModel
{
    public class ProdutoLojaViewModel
    {

        public String NomeProduto { get; set; }

        public ICollection<int> LojaId { get; set; }


    }
}
