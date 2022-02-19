using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fiap.Web.AspNet2.Repository.Interface;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Repository
{

    public class LojaRepository : ILojaRepository
    {

        private readonly DataContext context;

        public LojaRepository(DataContext dataContext)
        {
            context = dataContext;
        }

        public IList<LojaModel> FindAll()
        {
            return context.Lojas.ToList();
        }

        public LojaModel FindById(int id)
        {
            return context.Lojas // SELECT FROM tabela
                    .Include(l => l.ProdutosLojas ) // INNER JOIN Produtos da Loja
                        .ThenInclude( pl => pl.Produto) // INNER JOIN -- Detalhes do Produto
                            .SingleOrDefault( l => l.LojaId == id); // WHERE 
        }



    }
}
