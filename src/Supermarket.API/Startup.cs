﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Supermarket.API.Persistencia;
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
            /// Permite asociar el servicio de la BD
            /// </summary>
            /// <typeparam name="SupermarketApiContext"></typeparam>
            /// <returns></returns>
            services.AddDbContext<SupermarketApiContext>(
                op => op.UseInMemoryDatabase("SupermarketApi")
                );

            // Declaración para el manejo del patrón inyección de dependencia DI
            // de el repositorio que maneja la lógica de negocio de categorías
            // que son utilizados en el repositorio y el controlador
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
