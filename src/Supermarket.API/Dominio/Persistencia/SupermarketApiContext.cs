using Microsoft.EntityFrameworkCore;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext
    {
        /// <summary>
        /// Emula una base de datos
        /// </summary>
        /// <param name="Options"></param>
        /// <returns></returns>
        
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> Options) : base(Options)
        {
            /// <summary>
            /// Contructor de la clase
            /// </summary>
            /// <value></value>
            
        }
        //tablas 
        public DbSet<Categoria> categorias {get; set; }
        /// <summary>
        /// Dataset de la base de datos que representa Categoria
        /// </summary>
        /// <value></value>
        public DbSet<Producto> productos {get; set; }
        /// <summary>
        /// Dataset de la base de datos que representa Producto
        /// </summary>
        /// <value></value>
        

        //seed (DB memoria)

    }
}