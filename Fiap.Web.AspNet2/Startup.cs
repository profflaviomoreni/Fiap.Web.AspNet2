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
                c.CreateMap<LoginViewModel, LoginModel>();
                c.CreateMap<LoginModel, LoginViewModel>();

                c.CreateMap<ClienteViewModel, ClienteModel>();
                c.CreateMap<ClienteModel, ClienteViewModel>();

                c.CreateMap<IList<RepresentanteViewModel>, IList<RepresentanteModel>>();

                c.CreateMap<IList<ClienteViewModel>, IList<ClienteModel>>();
                c.CreateMap<IList<ClienteModel>, IList<ClienteViewModel>>();

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();

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
