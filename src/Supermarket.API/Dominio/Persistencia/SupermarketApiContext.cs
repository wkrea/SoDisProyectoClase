using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;


namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContex
    {
      //constructir
      public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
      {

          
      }
      //tablas "propiedades de la clase"
      public DbSset<Categoria> categorias { get; set; }
      public DbSset<Productos> productos { get; set; }

      //see de la base --DB memory
    }
}