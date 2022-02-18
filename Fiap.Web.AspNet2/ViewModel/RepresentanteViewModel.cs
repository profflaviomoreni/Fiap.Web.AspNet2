using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.ViewModel
{
    public class RepresentanteViewModel
    {
        public int RepresentanteId { get; set; }

        public String NomeRepresentante { get; set; }

        public IList<RepresentanteViewModel> Representantes { get; set; }

        public ICollection<ClienteViewModel> Clientes { get; set; }

        public RepresentanteViewModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }

        public RepresentanteViewModel()
        {
        }

    }
}
