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
        /// <summary>
        /// Añade el servicio al contenedor
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //AddTransient-AddDbContext-AddScoped-indica la forma del su ciclo de vida en la app
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            /// <summary>
            /// Servicio de la DB  toma arg el nombre de la clase que maneja en contexto
            /// </summary>
            /// <typeparam name="SupermarketApiContext">DBService</typeparam>
            /// <returns></returns>
            
            services.AddDbContext<SupermarketApiContext>(
                op => op.UseInMemoryDatabase("SupermarketApi")
                );
                //Declaracion para el manejo del patron inyeccion de dependencis DI
                //del repositorio que maneja la logica de negocio de categorias
                //AddTransient-tiene vida hasta que  de respuesta- controladores responden a solicitudes del cliente
                //                     Estructura      Implementacion
            services.AddTransient<ICategoriaRepo, CategoriaRepo>();

                /*
                    AddDbContext tiene vide mientras es invocado-singleton
                    services.AddDbContext<SupermarketApiContext>();
                */
           
                /*
                    AddScoped has life mientras el controlador este vivo-se usa mucho, 
                    generador de reportes o controlador de mucho uso
                    services.AddScoped<ICategoriaRepo, CategoriaRepo>();
                    services.AddScoped<CategoriaRepo>();
           
                */
            
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
    