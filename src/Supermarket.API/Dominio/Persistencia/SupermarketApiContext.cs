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
    }
}