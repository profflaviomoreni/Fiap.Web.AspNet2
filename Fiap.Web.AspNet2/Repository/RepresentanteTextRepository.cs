﻿using Fiap.Web.AspNet2.Data;
using Fiap.Web.AspNet2.Models;
using Fiap.Web.AspNet2.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.Web.AspNet2.Repository
{
    public class RepresentanteTextRepository : IRepresentanteRepository
    {
 
        public DataContext _context { get; set; }

        public RepresentanteTextRepository(DataContext context)
        {
            _context = context;
        }


        public IList<RepresentanteModel> FindAll()
        {
            return _context.Representantes.ToList<RepresentanteModel>(); ;
        }

        public RepresentanteModel FindById(int id)
        {
            return _context.Representantes.Find(id);
        }



        public RepresentanteModel FindByIdWithClientes(int id)
        {
            var representante = _context.Representantes // FROM
                .Include(r => r.Clientes) // INNER JOIN
                    .SingleOrDefault(r => r.RepresentanteId == id); // WHERE

            return representante;
        }

        public IList<RepresentanteModel> FindByName(string nome)
        {
            var representantes = _context
                    .Representantes
                        .Where(r => r.NomeRepresentante.Contains(nome))
                            .ToList();
            return representantes;
        }


        public void Insert(RepresentanteModel representanteModel)
        {
            _context.Representantes.Add(representanteModel);
            _context.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            _context.Representantes.Update(representanteModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RepresentanteModel representanteModel = new RepresentanteModel(id, "");
            Delete(representanteModel);
        }


        public void Delete(RepresentanteModel representanteModel)
        {
            _context.Representantes.Remove(representanteModel);
            _context.SaveChanges();
        }
    }
}
