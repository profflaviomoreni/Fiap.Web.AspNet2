using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository
    {
        public DataContext _context { get; set; }

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }


        public List<ClienteModel> FindAll()
        {
            return _context.Clientes.ToList<ClienteModel>(); ;
        }

        public ClienteModel FindById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Insert(ClienteModel ClienteModel)
        {
            _context.Clientes.Add(ClienteModel);
            _context.SaveChanges();
        }

        public void Update(ClienteModel ClienteModel)
        {
            _context.Clientes.Update(ClienteModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel ClienteModel = new ClienteModel(id, "", "");
            Delete(ClienteModel);
        }


        public void Delete(ClienteModel ClienteModel)
        {
            _context.Clientes.Remove(ClienteModel);
            _context.SaveChanges();
        }

    }
}
