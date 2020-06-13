using System.Collections.Generic;
namespace Supermarket.API.Dominio.Modelos
{
  /// <summary>
  /// la clase categoria permite relacionar los productos que pertenecen a una categoria para asi identificarlos en las mismas categorias es decir relaciona el producto con la categoria a la que pertenece o eso entiendo   
  /// </summary>

  public class Categoria
  {
    internal int id;
/// <summary>
      ///  identificador de cada categoria
      /// </summary>
      /// <value></value>

    public int Id { get; set; }
    /// <summary>
      /// se asigna un valor de tipo string que funciona para nombrar cada categoria
      /// </summary>
      /// <value></value>

    public string nombre { get; set; }
    /// <summary>
      /// retorna un listado de todos los productos que estan dentro de una categoria o de l categoria 
      /// </summary>
      /// <value></value>
    public IList<Productos> productos { get; set; }//Relacion entre las categoria y productos
  }
}