using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
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
            return _context.Clientes.ToList<ClienteModel>();
        }


        public List<ClienteModel> FindAllWithRepresentante()
        {
            var lista = _context.Clientes.Include(c => c.Representante).ToList();
            return lista;

        }

        public List<ClienteModel> FindAllOrderByNomeAsc()
        {
            return _context.Clientes.OrderBy( c => c.Nome ).ToList<ClienteModel>();
        }


        public List<ClienteModel> FindAllOrderByNomeDesc()
        {
            return _context.Clientes.OrderByDescending(c => c.Nome).ToList<ClienteModel>();
        }

        public List<ClienteModel> FindByNome(string nome)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome) )
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public List<ClienteModel> FindByEmail(string email)
        {
            return _context.Clientes
                .Where(c => c.Email.StartsWith(email))
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public List<ClienteModel> FindByNomeAndEmail(string nome, string email)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome) && c.Email.Contains(email) )
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public List<ClienteModel> FindByNomeAndEmailDinamico(string nome, string email)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome) && c.Email.Contains(email))
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public List<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int? idRepresentante)
        {
            return _context.Clientes
                .Where(c => c.Nome.Contains(nome) && 
                            c.Email.Contains(email) && 
                            (0 == idRepresentante || c.RepresentanteId == idRepresentante) 
                       )
                        .OrderByDescending(c => c.Nome)
                            .ToList<ClienteModel>();
        }


        public List<ClienteModel> FindByRepresentante(int idRepresentante)
        {
            return _context.Clientes
                .Where(c => c.RepresentanteId == idRepresentante)
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public ClienteModel FindById(int id)
        {

            var cliente =
                _context.Clientes // SELECT campos
                    .Include(c => c.Representante) // Add campos do Representante e Inner Join
                        .SingleOrDefault(c => c.ClienteId == id); // Where;

            return cliente;
        }

        public void Insert(ClienteModel clienteModel)
        {
            _context.Clientes.Add(clienteModel);
            _context.SaveChanges();
        }

        public void Update(ClienteModel clienteModel)
        {
            _context.Clientes.Update(clienteModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel clienteModel = new ClienteModel(id, "", "");
            Delete(clienteModel);
        }


        public void Delete(ClienteModel clienteModel)
        {
            _context.Clientes.Remove(clienteModel);
            _context.SaveChanges();
        }

    }
}
