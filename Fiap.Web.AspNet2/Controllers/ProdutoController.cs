using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly DataContext context;
        private readonly ProdutoRepository produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            context = dataContext;
            produtoRepository = new ProdutoRepository(context);
        }


        public IActionResult Index()
        {
            var p = produtoRepository.FindById(4);

            return View();
        }
    }
}
