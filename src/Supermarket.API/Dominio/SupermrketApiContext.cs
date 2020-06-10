using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;


namespace Supermarket.API.Dominio.Persistencia
{
  /// <summary>
  /// la propiedad Dbcontext permite representar o simular en la base de datos funcionando como una clase 
  /// </summary>
    public class SupermarketApiContext : DbContext

    {
      //constructor
      /// <summary>
      /// opciones que posee el string de conexion y se utilizan para emparejar los servicios que serviran pra correr la aplicacion 
      /// </summary>
      /// <param name="options"></param>
      /// <returns></returns>
      public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
      {

          PoblarBase();
          Database.EnsureCreated();
      }
      //tablas "propiedades de la clase" conocidas como nombre de dominio
      public DbSet<Categoria> categorias { get; set; }

      public DbSet<Producto> productos { get; set; }

      //see de la base (semillas de informacion) --DB memory
      public void PoblarBase()
      {
        this.categorias.add(
          new Categoria{
              id = 1,
              nombre = "Categoria 1"
          }
        );
        this.categorias.add(
          new Categoria{
              id = 2,
              nombre = "Categoria 2"
          }
        );
        //commit 
        this.SaveChanges();

      }
    }
}