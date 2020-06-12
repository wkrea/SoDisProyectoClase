using System.Reflection.Emit;
using System.Reflection;
using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
  /// <summary>
  /// Me permite definir la forma como se manejara la bd el DbContext me sirve como emulador que me da el EntityFrameworkCore
  /// </summary>
    public class SupermarketApiContext : DbContext
    {
      /// <summary>
      /// Creacion del contructor de esta clase que deriva del DbContext
      /// </summary>
      /// <param name="options">Son las que poseen el string de conexion y permiten definirse en startups.cs </param>
      /// <returns></returns>
      public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
      {   
        PoblarBase();
        Database.EnsureCreated();       
      }
      /// <summary>
      /// Tabla que representa la categoria
      /// </summary>
      /// <value></value>
      public DbSet<Categoria> categorias {get; set;}
      /// <summary>
      /// Tabla que representa el producto
      /// </summary>
      /// <value></value>
      public DbSet<Producto> productos {get; set;}
      
      public void PoblarBase()
      {
        this.categorias.AddAsync(
          new Categoria{
              id = 1,
              nombre = "Categoria 1"
          }
        );
        this.categorias.AddAsync(
          new Categoria{
              id = 2,
              nombre = "Categoria 2"
          }
        );
        //commit 
        this.SaveChanges();

      }


    /// <summary>
    /// Divi context 
    /// </summary>
/*
   protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Categoria>().ToTable("Categoria");
      builder.Entity<Categoria>().HasKey(Categoria => Categoria.id);
      IEnumerable<int> scoreQuery = from score in scores
                                    where score > 80
                                    select score;

    }
*/
    }
}