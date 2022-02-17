using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;


namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface IClienteRepository
    {

        public IList<ClienteModel> FindAll();

        public IList<ClienteModel> FindAllWithRepresentante();

        public IList<ClienteModel> FindAllOrderByNomeAsc();

        public IList<ClienteModel> FindAllOrderByNomeDesc();

        public IList<ClienteModel> FindByNome(string nome);

        public IList<ClienteModel> FindByEmail(string email);

        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email);

        public IList<ClienteModel> FindByNomeAndEmailDinamico(string nome, string email);

        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int? idRepresentante);

        public IList<ClienteModel> FindByRepresentante(int idRepresentante);

        public ClienteModel FindById(int id);

        public void Insert(ClienteModel clienteModel);

        public void Update(ClienteModel clienteModel);

        public void Delete(int id);

        public void Delete(ClienteModel clienteModel);

    }
}
