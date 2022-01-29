using Fiap.Web.AspNet2.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
            //Abrindo a tela para inserir um novo Cliente
            return View();
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            //Capturando os dados de um novo cliente
            return View("Sucesso");
        }


        //Abrir a tela de Edição - Consulta
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ClienteModel clienteModel;

            if (id == 1)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 1,
                    Nome = "Flavio",
                    Email = "fmoreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS1"
                };
            } else if ( id == 2)  {
                clienteModel = new ClienteModel
                {
                    ClienteId = 2,
                    Nome = "Eduardo",
                    Email = "eduardo@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            } else if ( id == 3)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 3,
                    Nome = "Moreni",
                    Email = "moreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }




            return View();
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
