﻿using AutoMapper;
using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {

        private readonly IRepresentanteRepository repository;
        private readonly IMapper mapper;

        public RepresentanteController(IRepresentanteRepository _representanteRepository, IMapper _mapper)
        {
            repository = _representanteRepository;
            mapper = _mapper;
        }



        
        public IActionResult Index()
        {
            var representantes = mapper.Map<IList<RepresentanteViewModel>>(repository.FindAll());

            var listaRepresentantes = repository.FindAll();
            return View(listaRepresentantes);
        }
        

        public IActionResult Details(int id)
        {
            //var representanteModel =  repository.FindById(id);
            var representanteModel = repository.FindByIdWithClientes(id);

            if (representanteModel == null)
            {
                return NotFound();
            }
            return View(representanteModel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(representanteModel);

                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }


        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = repository.FindById(id);

            if (representanteModel == null)
            {
                return NotFound();
            }
            return View(representanteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (id != representanteModel.RepresentanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               repository.Update(representanteModel);
               return RedirectToAction(nameof(Index));

            }
            return View(representanteModel);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = repository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        
        
    }
}
