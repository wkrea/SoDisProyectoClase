using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext
    {
        //Constructor
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {

        }

        //Tablas props  de la clase
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}