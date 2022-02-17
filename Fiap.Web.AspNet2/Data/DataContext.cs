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

        public DbSet<LojaModel> Lojas { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<ProdutoLojaModel> ProdutosLojas { get; set; }

        public DbSet<PaisModel> Paises { get; set; }

        public DbSet<LoginModel> Login { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PaisModel>()
                .ToTable("Pais")
                .HasKey(p => p.PaisId);

            modelBuilder.Entity<PaisModel>()
                .Property(p => p.PaisId).ValueGeneratedOnAdd();

            modelBuilder.Entity<PaisModel>()
                .Property(p => p.NomePais)
                    .HasMaxLength(30)
                    .IsRequired();

            modelBuilder.Entity<PaisModel>()
                .HasIndex(p => p.NomePais);



            modelBuilder.Entity<PaisModel>().HasData(
                new PaisModel(1,"Brasil","America do Sul"),
                new PaisModel(2,"Alemanha","Europa")
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
