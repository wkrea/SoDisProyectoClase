using System.Collections.Generic;
namespace Supermarket.API.Dominio.Modelos
{
  /// <summary>
  /// Esta clase me permite definir las propiedades que llevaran las categorias que tendran dentro sus respectivos productos
  /// </summary>
  public class Categoria
  {
    internal int id;

    /// <summary>
    /// Esta propiedad contiene el identificator de la categoria que facilitara su extracion 
    /// </summary>
    /// <value>Id</value>
    public int Id { get; set; }
    /// <summary>
    /// Esta propiedad contiene el nombre de la categoria
    /// </summary>
    /// <value></value>
    public string nombre { get; set; }
    /// <summary>
    /// Listado de productos que me permite opbtener los prodcutos que estan dentro de la categoria
    /// </summary>
    /// <value></value>
    public IList<Producto> productos { get; set; }
  }
}