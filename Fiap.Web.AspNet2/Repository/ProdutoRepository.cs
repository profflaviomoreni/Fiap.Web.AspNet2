﻿using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext context;

        public ProdutoRepository(DataContext dataContext)
        {
            context = dataContext;
        }


        public ProdutoModel FindById(int id)
        {
            var p = context.Produtos // FROM
                    .Include(p => p.ProdutosLojas) // INNER JOIN
                        .ThenInclude( pl => pl.Loja ) // INNER JOIN 
                            .SingleOrDefault(p => p.ProdutoId == id); // WHERE

            return p;
        }


    }
}
