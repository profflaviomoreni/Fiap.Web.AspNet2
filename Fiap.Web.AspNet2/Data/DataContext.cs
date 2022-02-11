using Fiap.Web.AspNet2.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }


        public DbSet<RepresentanteModel> Representantes { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }


    }
}
