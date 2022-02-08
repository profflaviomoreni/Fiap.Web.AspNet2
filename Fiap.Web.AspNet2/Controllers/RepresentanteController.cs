﻿using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly DataContext _context;

        public RepresentanteController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaRepresentantes = _context.Representantes.ToList<RepresentanteModel>();
            return View(listaRepresentantes);
        }


        public IActionResult Details(int? id)
        {
            var representanteModel =  _context.Representantes.Find(id);
            
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
                _context.Add(representanteModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = _context.Representantes.Find(id);
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
                try
                {
                    _context.Update(representanteModel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepresentanteModelExists(representanteModel.RepresentanteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var representanteModel = _context.Representantes.FirstOrDefault(m => m.RepresentanteId == id);
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
            var representanteModel =  _context.Representantes.Find(id);
            _context.Representantes.Remove(representanteModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RepresentanteModelExists(int id)
        {
            return _context.Representantes.Any(e => e.RepresentanteId == id);
        }
        
    }
}
