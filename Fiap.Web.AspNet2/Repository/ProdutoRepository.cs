using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ProdutoRepository: IProdutoRepository
    {

        private readonly DataContext context;

        public ProdutoRepository(DataContext dataContext)
        {
            context = dataContext;
        }


        public IList<ProdutoModel> FindAll()
        {
            return context.Produtos.ToList();
        }

        public ProdutoModel FindById(int id)
        {
            var p = context.Produtos // FROM
                    .Include(p => p.ProdutosLojas) // INNER JOIN
                        .ThenInclude( pl => pl.Loja ) // INNER JOIN 
                            .SingleOrDefault(p => p.ProdutoId == id); // WHERE

            return p;
        }

        public int Insert(ProdutoModel produtoModel)
        {
            context.Produtos.Add(produtoModel);
            context.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Delete(int id)
        {
            context.Produtos.Remove(new ProdutoModel() { ProdutoId = id });
            context.SaveChanges();
        }

        public void Update(ProdutoModel produtoModelNovo)
        {
            var produtoAtual = FindById(produtoModelNovo.ProdutoId);
            produtoAtual.NomeProduto = produtoModelNovo.NomeProduto;
            produtoAtual.ProdutosLojas = produtoModelNovo.ProdutosLojas;

            context.Produtos.Update(produtoAtual);
            context.SaveChanges();

        }



    }
}
