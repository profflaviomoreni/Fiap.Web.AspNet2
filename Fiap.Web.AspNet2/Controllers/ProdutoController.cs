using AutoMapper;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        public ProdutoController(
            IProdutoRepository _produtoRepository, 
            ILojaRepository _lojaRepository, 
            IMapper _mapper)
        {
            produtoRepository = _produtoRepository;
            lojaRepository = _lojaRepository;
            mapper = _mapper;
        }


        public IActionResult Index()
        {
            /*
            IList<ProdutoModel> produtos = produtoRepository.FindAll();
            IList<ProdutoViewModel> produtoViewModels = mapper.Map<IList<ProdutoViewModel>>(produtos);  
            */

            var produtos = produtoRepository.FindAll();
            var produtoViewModels = mapper.Map<IList<ProdutoViewModel>>(produtos);

            return View(produtoViewModels);
        }


        [HttpGet]
        public IActionResult Novo()
        {
            var lojas = lojaRepository.FindAll();
            var lojasVM = mapper.Map <IList<LojaViewModel>>(lojas);
            ViewBag.Lojas = lojasVM;

            return View( new ProdutoLojaViewModel());
        }

        [HttpPost]
        public IActionResult Novo(ProdutoLojaViewModel produtoLojaViewModel)
        {

            try
            {
                ProdutoModel produtoModel = mapper.Map<ProdutoModel>(produtoLojaViewModel);
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                foreach (var loja in produtoLojaViewModel.LojaId)
                {
                    ProdutoLojaModel produtoLojaModel = new ProdutoLojaModel()
                    {
                        LojaId = loja,
                        Produto = produtoModel
                    };

                    produtoModel.ProdutosLojas.Add(produtoLojaModel);
                }

                produtoRepository.Insert(produtoModel);
                TempData["mensagem"] = "Produto cadastrado com sucesso";

            } catch (Exception e)
            {
                TempData["mensagem"] = $"Não foi possível cadastrar o produto. Detalhe {e.Message}";
            }

            
            return RedirectToAction("Index");
        }



    }
}
