using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Dominio.Persistencia;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            /// <summary>
            /// construccion de objeto
            /// </summary>
            /// <typeparam name="SupermarketApiContext"></typeparam>
            /// <returns></returns>
            services.AddDbContext<SupermarketApiContext>(
                op => op.UseInMemoryDatabase("SupermarketApi")
            );
            /// <summary>
            /// declaracion para el manejo del patron inyeccion de dependencia DI del repositorio 
            /// que maneja la logica de negocio de categorias Controladores
            /// </summary>
            /// <typeparam name="ICategoriaRepo"></typeparam>
            /// <typeparam name="CategoriaRepo"></typeparam>
            /// <returns></returns>
            services.AddTransient<ICategoriaRepo, CategoriaRepo>();
            /// 
            services.AddDbContext<SupermarketApiContext>();
            services.AddScoped<ICategoriaRepo, CategoriaRepo>();
            services.AddScoped<CategoriaRepo>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}