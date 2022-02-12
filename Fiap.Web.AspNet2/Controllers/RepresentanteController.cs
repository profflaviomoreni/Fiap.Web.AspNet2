using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.AspNet2.Controllers
{
    public class RepresentanteController : Controller
    {
        private readonly DataContext _context;

        private readonly RepresentanteRepository repository;

        public RepresentanteController(DataContext context)
        {
            _context = context;
            repository = new RepresentanteRepository(_context);
        }

        public IActionResult Index()
        {
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
