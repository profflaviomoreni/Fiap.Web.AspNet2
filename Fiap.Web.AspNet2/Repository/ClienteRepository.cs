using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;

        public ClienteRepository(DataContext ctx)
        {
            context = ctx;
        }


        public IList<ClienteModel> FindAll()
        {
            return context.Clientes.ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindAllWithRepresentante()
        {
            var ILista = context.Clientes.Include(c => c.Representante).ToList();
            return ILista;

        }

        public IList<ClienteModel> FindAllOrderByNomeAsc()
        {
            return context.Clientes.OrderBy( c => c.Nome ).ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindAllOrderByNomeDesc()
        {
            return context.Clientes.OrderByDescending(c => c.Nome).ToList<ClienteModel>();
        }

        public IList<ClienteModel> FindByNome(string nome)
        {
            return context.Clientes
                .Where(c => c.Nome.Contains(nome) )
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindByEmail(string email)
        {
            return context.Clientes
                .Where(c => c.Email.StartsWith(email))
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email)
        {
            return context.Clientes
                .Where(c => c.Nome.Contains(nome) && c.Email.Contains(email) )
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindByNomeAndEmailDinamico(string nome, string email)
        {
            return context.Clientes
                .Where(c => c.Nome.Contains(nome) && c.Email.Contains(email))
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int? idRepresentante)
        {
            return context.Clientes
                .Where(c => c.Nome.Contains(nome) && 
                            c.Email.Contains(email) && 
                            (0 == idRepresentante || c.RepresentanteId == idRepresentante) 
                       )
                        .OrderByDescending(c => c.Nome)
                            .ToList<ClienteModel>();
        }


        public IList<ClienteModel> FindByRepresentante(int idRepresentante)
        {
            return context.Clientes
                .Where(c => c.RepresentanteId == idRepresentante)
                    .OrderByDescending(c => c.Nome)
                        .ToList<ClienteModel>();
        }


        public ClienteModel FindById(int id)
        {

            var cliente =
                context.Clientes // SELECT campos
                    .Include(c => c.Representante) // Add campos do Representante e Inner Join
                        .SingleOrDefault(c => c.ClienteId == id); // Where;

            return cliente;
        }

        public void Insert(ClienteModel clienteModel)
        {
            context.Clientes.Add(clienteModel);
            context.SaveChanges();
        }

        public void Update(ClienteModel clienteModel)
        {
            context.Clientes.Update(clienteModel);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.ClienteId = id;
            Delete(clienteModel);
        }


        public void Delete(ClienteModel clienteModel)
        {
            context.Clientes.Remove(clienteModel);
            context.SaveChanges();
        }

    }
}
