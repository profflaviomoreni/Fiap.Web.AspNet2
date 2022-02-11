using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteRepository
    {

        public DataContext _context { get; set; }

        public RepresentanteRepository(DataContext context)
        {
            _context = context;
        }


        public List<RepresentanteModel> FindAll()
        {
            return _context.Representantes.ToList<RepresentanteModel>(); ;
        }

        public RepresentanteModel FindById(int id) {
            return _context.Representantes.Find(id);
        }

        public void Insert(RepresentanteModel representanteModel)
        {
            _context.Representantes.Add(representanteModel);
            _context.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            _context.Representantes.Update(representanteModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RepresentanteModel representanteModel = new RepresentanteModel(id, "");
            Delete(representanteModel);
        }


        public void Delete(RepresentanteModel representanteModel)
        {
            _context.Representantes.Remove(representanteModel);
            _context.SaveChanges();
        }


    }
}
