using Fiap.Web.AspNet2.Models;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository.Interface
{
    public interface IProdutoRepository
    {

        public IList<ProdutoModel> FindAll();

        public ProdutoModel FindById(int id);

        public int Insert(ProdutoModel produtoModel);

        public void Delete(int id);

        public void Update(ProdutoModel produtoModelNovo);

    }
}
