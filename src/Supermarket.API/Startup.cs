using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Persistencia;

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

            //Declaración para el manejo del patrón inyección de dependencia DI
            //de el reporsitorio que maneje la lógica de  negocio de categorías.
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
