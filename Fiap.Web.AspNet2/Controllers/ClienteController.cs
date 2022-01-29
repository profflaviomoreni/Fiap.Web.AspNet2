using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar()
        {
            var nome = Request.Form["Nome"];
            var email = Request.Form["Email"];

            // Insert into ;;; nome e email;

            return View("Sucesso");
        }



        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Conteudo()
        {
            return Content("Retornando o conteúdo em String");
        }

        
        public IActionResult Redirect()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
