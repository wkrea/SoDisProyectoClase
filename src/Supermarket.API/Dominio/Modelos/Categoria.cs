using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria
    {
      public int Id { get; set; }
      public string nombre { get; set; }

      /// <summary>
      /// Me permite obtener el listado de los productos que estan dentro de la categoria
      /// </summary>
      /// <value></value>
      public IList<Producto> productos {get; set;} //Relacion entre las categoria y productos
      
    }
}