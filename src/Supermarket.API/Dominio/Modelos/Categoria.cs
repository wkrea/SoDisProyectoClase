using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
  /// <summary>
  /// En esta clase Categoria es donde se relacionaran los productos que pertenecen a x categoria para poderlos indexar de forma mas facil por grupos que seran las categorias a las que pertenecen
  /// </summary>
    public class Categoria
    {
      /// <summary>
      /// Propiedad que funciona como identificador de cada categoria
      /// </summary>
      /// <value></value>
      public int Id { get; set; }

      /// <summary>
      /// Esta propiedad me permite asignarle un valor de tipo string que funcionara para dar el nomre a cada categoria
      /// </summary>
      /// <value></value>
      public string nombre { get; set; }

      /// <summary>
      /// Me permite obtener el listado de los productos que estan dentro de la categoria
      /// </summary>
      /// <value></value>
      public IList<Producto> productos {get; set;} //Relacion entre las categoria y productos
      
    }
}