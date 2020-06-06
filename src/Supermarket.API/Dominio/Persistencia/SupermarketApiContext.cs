using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;


namespace Supermarket.API.Dominio.Persistencia
{
  /// <summary>
  /// Permite simular a la base de datos virtual como un orm para que funciones como una clase gracias a la propiedad DbContext que es de EntityFrameworkCore
  /// </summary>
    public class SupermarketApiContext : DbContex
    {
      //constructor
      /// <summary>
      /// Son las opciones que poseen el string de conexion y se implimentan para unir los servicios para correr la aplicacion me lleva la conexion a startup que es lo que mas me pericio interesante por que lo unifica como un solo servicio para no meter mano a todo esto :D
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