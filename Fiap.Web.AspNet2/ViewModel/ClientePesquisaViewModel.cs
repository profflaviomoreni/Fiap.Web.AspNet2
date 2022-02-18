using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class ClientePesquisaViewModel
    {

        public String NomePesquisa { get; set; }

        public String EmailPesquisa { get; set; }

        public IList<ClienteViewModel> Clientes { get; set; }

    }
}
