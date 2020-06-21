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
            /// Agregar el servicio de la base de datos en memoria
            /// </summary>
            /// <returns></returns>
            services.AddDbContext<SupermarketApiContext>(
                op => op.UseInMemoryDatabase("SupermarketApi")
            );   

            //Declaracion para el manejo del patron inyeccion de dependencias UDI     
            //del repositorio que maneja la logico de negocio de categoria

            /// <summary>
            /// Agregar el servicio 
            /// </summary>
            /// <typeparam name="ICategoriaRepo"></typeparam>
            /// <typeparam name="CategoriaRepo"></typeparam>
            /// <returns></returns>
            services.AddTransient<ICategoriaRepo, CategoriaRepo>();

            
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
