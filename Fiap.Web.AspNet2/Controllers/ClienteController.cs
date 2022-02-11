using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        private readonly RepresentanteRepository representanteRepository;
        private readonly ClienteRepository clienteRepository;

        public ClienteController(DataContext dataContext)
        {
            representanteRepository = new RepresentanteRepository(dataContext);
            clienteRepository = new ClienteRepository(dataContext);            
        }


        [HttpGet]
        public IActionResult Index()
        {
            var listaClientes = clienteRepository.FindAll();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            ViewBag.representantes = listaRepresentantes;

            return View( new ClienteModel() );
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {

            if ( ModelState.IsValid )
            {
                clienteRepository.Insert(clienteModel);

                TempData["MensagemSucesso"] = $"Cliente {clienteModel.Nome} inserido com sucesso";
                return RedirectToAction("Index");

            } else
            {
                ViewBag.representantes = representanteRepository.FindAll();
                return View(clienteModel);
            }

        }


        [HttpGet]
        public IActionResult Editar(int id)
        {

            ClienteModel clienteModel = clienteRepository.FindById(id);

            IList<RepresentanteModel> representantes = representanteRepository.FindAll();
            ViewBag.representantes = new SelectList(representantes, "RepresentanteId", "NomeRepresentante");

            return View(clienteModel);
        }


        

        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {

            if (ModelState.IsValid)
            {

                clienteRepository.Update(clienteModel);

                TempData["MensagemSucesso"] = $"Cliente {clienteModel.Nome} alterado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                IList<RepresentanteModel> representantes = representanteRepository.FindAll();
                ViewBag.representantes = new SelectList(representantes, "RepresentanteId", "NomeRepresentante");

                return View(clienteModel);
            }

        }


        //Abrir a tela de Edição - Consulta
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            ClienteModel clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
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
