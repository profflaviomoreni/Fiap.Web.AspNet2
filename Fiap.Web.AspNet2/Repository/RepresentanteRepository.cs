using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository
    {
        private List<RepresentanteModel> representantes;

        public RepresentanteRepository()
        {
            representantes = new List<RepresentanteModel>();
            representantes.Add(new RepresentanteModel(1, "Repre 1"));
            representantes.Add(new RepresentanteModel(2, "Repre 2"));
            representantes.Add(new RepresentanteModel(3, "Repre 3"));
            representantes.Add(new RepresentanteModel(4, "Repre 4"));
            representantes.Add(new RepresentanteModel(5, "Repre 5"));
            representantes.Add(new RepresentanteModel(6, "Repre 6"));
        }


        public List<RepresentanteModel> FindAll()
        {
            
            return representantes;
        }

    }
}
