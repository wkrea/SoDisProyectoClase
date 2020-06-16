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
            PoblarBase();
            Database.EnsureCreated();
        }

        // Tablas "propiedades de la clase"
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }

        // Seed de la base (Semillas de información) -- DB en memoria
        public void PoblarBase()
        {
            this.categorias.Add(
                new Categoria{
                    id = 1,
                    nombre = "Categoria 1"
                }
            );

            this.categorias.Add(
                new Categoria{
                    id = 2,
                    nombre = "Categoria 2"
                }
            );

            // commit
            this.SaveChanges();
        }
    }
}