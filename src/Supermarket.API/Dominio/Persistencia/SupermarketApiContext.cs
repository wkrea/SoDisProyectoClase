using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    /// <summary>
    /// modelo para definicion y descripcion de la base de datos
    /// </summary>
    public class SupermarketApiContext : DbContext
    {
        // Cobstructor 
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {

        }

        // Tablas "propiedades de la clase"
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }

        // Seed de la base (Semillas de información) -- DB en memoria
    }
}