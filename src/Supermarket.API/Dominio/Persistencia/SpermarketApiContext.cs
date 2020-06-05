using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
    /// <summary>
    /// Se define la clase para emular una BD relacionar
    /// Aquí se emula la base de datos como si fuese una clase
    /// en este caso deriba de DbContext que es quien se encarga de manipular la base
    /// </summary>
    public class SupermarketApiContext : DbContext
    {
            //Constructo 
            public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base (options)
            {
        
            }
            //Tablas 
            public DbSet<Categoria> categorias {get; set;}
             public DbSet<Producto> productos {get; set;}

   }
}