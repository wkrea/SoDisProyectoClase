using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;


namespace Supermarket.API.Dominio.Persistencia
{
  /// <summary>
  /// la propiedad Dbcontext permite representar o simular en la base de datos funcionando como una clase 
  /// </summary>
    public class SupermarketApiContext : DbContex
    {
      //constructor
      /// <summary>
      /// opciones que posee el string de conexion y se utilizan para emparejar los servicios que serviran pra correr la aplicacion 
      /// </summary>
      /// <param name="options"></param>
      /// <returns></returns>
      public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
      {

          
      }
      //tablas "propiedades de la clase" conocidas como nombre de dominio
      public DbSset<Categoria> categorias { get; set; }
      public DbSset<Productos> productos { get; set; }

      //see de la base --DB memory
    }
}