using System;

namespace Fiap.Web.AspNet2.Models
{
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


        public int RepresentanteId { get; set; }

        public String NomeRepresentante { get; set; }

    }
}
