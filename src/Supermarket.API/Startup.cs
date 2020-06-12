using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Persistencia;
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
            //Creacion de base de datos en memoria
            services.AddDbContext<SupermarketApiContext>(
                op=> op.UseInMemoryDatabase("SupermarketApi")
            );
            //Declaracion para el manejo del patron  de  inyeccion de dependencias.
            //de el repositorio que maneja la logica de negocio de Categorias
            services.AddTransient<ICategoriaRepo,CategoriaRepo>();
        /// <summary>
        ///Representan el ciclo de vida de las instancias u objetos
        /// services.AddDbContext<SupermarketApiContext>();
        /// services.AddScoped<CategoriaRepo>();
        /// dbcontex se invoca accede y se inhabilita(ejem.utilizar conexion a la base)
        /// scope mientras el controlador se este ejecutando(ejem.utilizar generador de reportes )
        /// Transient vive en el momento de la respuesta.(ejem.utilizar controladores)
        /// </summary>
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
