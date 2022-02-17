using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet2.Controllers
{
    public class LojaController : Controller
    {

        private readonly ILojaRepository lojaRepository;

        public LojaController(ILojaRepository repository)
        {
            lojaRepository = repository;
        }


        public IActionResult Index()
        {
            var l = lojaRepository.FindById(1);

            return View();
        }
    }
}
