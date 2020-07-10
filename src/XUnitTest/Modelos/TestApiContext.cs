using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace xTest.Modelos
{
    public class TestApiContext : DbContext
    {
        public TestApiContext(DbContextOptions<TestApiContext> op) : base(op)
        {
            
        }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
    }
}