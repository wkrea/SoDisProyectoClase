using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext: DbContext
    {
         //Contructor
           public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
           {
           }
         //Tablas "props de la clase"
         
               public DbSet<Categoria> categorias {get; set;}
                public DbSet<Producto> productos {get; set;}

         //Seed de la base (semillas de informacion) -- DB en memoria
        
    }
}