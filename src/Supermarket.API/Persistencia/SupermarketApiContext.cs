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
            }

        public DbSet<Categoria> Categorias { get; set; }

        public void PoblarBaseDatos()
        {
            this.Categorias.Add(
                new Categoria{
                    Nombre = "Categoria1"
                }
            );

            // Equivale a commit sobre la Db en memoria.
            this.SaveChanges();
        }
    }
}