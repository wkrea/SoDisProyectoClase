namespace Supermarket.API.Dominio.Modelos
{
  /// <summary>
  /// Esta clase me permite crear los productos que estaran contenidos dentro de categoria
  /// </summary>
  public class Producto
  {
    /// <summary>
    /// Esta propiedad contiene el identificator del producto que facilitara su extracion 
    /// </summary>
    /// <value>Id</value>
    public int Id { get; set; }
    /// <summary>
    /// Esta propiedad contiene el nombre del producto
    /// </summary>
    /// <value></value>
    public string nombre { get; set; }
    /// <summary>
    /// Esta propiedad me determina la cantidad de productos que hay del mismo 
    /// </summary>
    /// <value></value>
    public int cantidadxPaquete { get; set; }    
    //public EUnidadDeMedida UnidadDeMedida { get; set; }
    /// <summary>
    /// Relaciona a que categoria pertenece el producto con el fin de obtener infromacion requerida
    /// </summary>
    /// <value></value>
    public int categoriaId { get; set; }
    /// <summary>
    /// Categoria a la cual pertenece el categoriaId 
    /// </summary>
    /// <value></value>
    public Categoria categoria {get; set; }
  }
}