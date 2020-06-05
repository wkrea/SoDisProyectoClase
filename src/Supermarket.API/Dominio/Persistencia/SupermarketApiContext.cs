using Microsoft.EntityFrameworkCore;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext
    {
        /// <summary>
        /// Simula una base de datos
        /// </summary>
        /// <param name="Options"></param>
        /// <returns></returns>
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> Options) : base(Options)
        {
            
        }
        //tablas 
        public DbSet<Categoria> categorias {get; set; }
        
        public DbSet<Producto> productos {get; set; }

        //seed (DB memoria) Semillas

    }
}