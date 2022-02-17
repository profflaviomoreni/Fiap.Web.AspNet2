using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IRepresentanteRepository representanteRepository;
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IRepresentanteRepository representante, IClienteRepository cliente )
        {
            representanteRepository = representante;
            clienteRepository = cliente;            
        }


        [HttpGet]
        public IActionResult Index()
        {
            //var listaClientes = clienteRepository.FindAll();
            //var listaClientes = clienteRepository.FindAllOrderByNomeAsc();
            //var listaClientes = clienteRepository.FindAllOrderByNomeDesc();
            //var listaClientes = clienteRepository.FindByNome("ana");
            //var listaClientes = clienteRepository.FindByEmail("a");
            //var listaClientes = clienteRepository.FindByNomeAndEmail("na","gmail.com");
            //var listaClientes = clienteRepository.FindByRepresentante(3);

            var listaClientes = clienteRepository.FindByNomeAndEmailAndRepresentante("na", ".br", 3);

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
