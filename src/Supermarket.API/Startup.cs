using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        //Permite la integracion de todos los diferentes servicios del proyecto
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //Construye un ojeto de SupermarketApiContext
            services.AddDbContext<SupermarketApiContext>(op => op.UseInMemoryDatabase("SupermarketApi"));
            // No entendi muy bien 

            services.AddTransient<ICategoriaRepo, CategoriaRepo>();
            // debe resirver el que da la informacion y donde se implementan 
            services.AddDbContext<SupermarketApiContext>();

            services.AddScoped<ICategoriaRepo, CategoriaRepo> ();
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
