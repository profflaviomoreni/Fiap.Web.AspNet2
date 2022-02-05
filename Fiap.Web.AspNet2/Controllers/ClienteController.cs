using Fiap.Web.AspNet2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ClienteController : Controller
    {

        public List<ClienteModel> listaClientes { get; set; }


        public ClienteController()
        {
            listaClientes = new List<ClienteModel>();
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 1,
                Nome = "Flavio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS1"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
        }


        [HttpGet]
        public IActionResult Index()
        {
            //listaClientes = clienteRepository.findall();

            //ViewBag.Mensagem = "Último acesso foi em 01/01/2000";

            return View(listaClientes);
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

            if ( ModelState.IsValid )
            {
                //clienteRepo.save(clienteModel);

                //Capturando os dados de um novo cliente

                //ViewBag.Mensagem = "Cliente " + clienteModel.Nome + " inserido com suceso";
                TempData["MensagemSucesso"] = $"Cliente {clienteModel.Nome} inserido com sucesso";

                return RedirectToAction("Index");
            } else
            {
                return View(clienteModel);
            }


            
        }


        //Abrir a tela de Edição - Consulta
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ClienteModel clienteModel = new ClienteModel();

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

            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            //Capturando os dados de um cliente alterado 

            TempData["MensagemSucesso"] = $"Cliente {clienteModel.Nome} alterado com sucesso";

            return RedirectToAction("Index");
        }


        //Abrir a tela de Edição - Consulta
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            ClienteModel clienteModel = new ClienteModel();

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
            }
            else if (id == 2)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 2,
                    Nome = "Eduardo",
                    Email = "eduardo@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }
            else if (id == 3)
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
