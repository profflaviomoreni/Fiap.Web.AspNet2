using Fiap.Web.AspNet2.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Web.AspNet2.Repository.Interface;
using Fiap.Web.AspNet2.Repository;
using Fiap.Web.AspNet2.ViewModel;
using Fiap.Web.AspNet2.Models;
using AutoMapper;

namespace Fiap.Web.AspNet2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("databaseUrl");
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString)
                                             .EnableSensitiveDataLogging()
                                             );


            var mapperConfig = new AutoMapper.MapperConfiguration(c =>
            {
                c.AllowNullCollections = true;

                // Login
                c.CreateMap<LoginViewModel, LoginModel>();
                c.CreateMap<LoginModel, LoginViewModel>();


                // Representante
                c.CreateMap<RepresentanteViewModel, RepresentanteModel>();

                c.CreateMap<RepresentanteModel, RepresentanteViewModel>()
                    .ForMember(v => v.RepresentanteId, m => m.MapFrom(x => x.RepresentanteId))
                    .ForMember(v => v.NomeRepresentante, m => m.MapFrom(x => x.RepresentanteId))
                    .ForMember(v => v.Clientes, m => m.MapFrom(x => x.Clientes));

                c.CreateMap<IList<RepresentanteViewModel>, IList<RepresentanteModel>>();


                // Cliente
                c.CreateMap<ClienteViewModel, ClienteModel>()
                    .ForMember(c => c.Representante, opt => opt.Ignore());

                c.CreateMap<ClienteModel, ClienteViewModel>();
                c.CreateMap<IList<ClienteViewModel>, IList<ClienteModel>>();


                //Produto
                c.CreateMap<ProdutoViewModel, ProdutoModel>()
                    .ForMember(p => p.ProdutosLojas, opt => opt.Ignore());
                c.CreateMap<ProdutoModel, ProdutoViewModel>();
                c.CreateMap<IList<ProdutoViewModel> , IList<ProdutoModel>> ();


                //Loja
                c.CreateMap<LojaViewModel, LojaModel>()
                    .ForMember(l => l.ProdutosLojas, opt => opt.Ignore());
                c.CreateMap<LojaModel, LojaViewModel>();



                //ProdutoLoja
                c.CreateMap<ProdutoLojaViewModel, ProdutoModel>()
                    .ForMember(p => p.ProdutosLojas, opt => opt.Ignore());

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
