using Microsoft.EntityFrameworkCore;

using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Persistencia 
{
    public class SupermarketApiContext : DbContext 
    {
        public SupermarketApiContext (
            DbContextOptions<SupermarketApiContext> options) : base (options) 
            { 
                PoblarBaseDatos();
                Database.EnsureCreated();
            }

        // Tablas "props de la clase"
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }

        // Seed de la base (semillas de información) -- DB en memoria
        public void PoblarBaseDatos()
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