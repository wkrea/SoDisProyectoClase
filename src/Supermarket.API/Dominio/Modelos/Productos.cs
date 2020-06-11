namespace Supermarket.API.Dominio.Modelos
{

  /// <summary>
  ///  l clase producto almacena los productos que poseen un id, nombre y cantidad, y la categoria a la cual pertenence 
  /// </summary>
    public class Producto
    {
      /// <summary>
      ///identificador de cada producto 
      /// </summary>
      /// <value></value>
      public int Id { get; set; }

      /// <summary>
      /// Ese asigna un valor de tipo string que funciona para nombrar cada producto
      /// </summary>
      /// <value></value>
      public string nombre { get; set; }
      
      /// <summary>
      /// no entendi bien pero creo que concede saber cuantos ´productos existen  
      /// </summary>
      /// <value></value>

      public int cantidadxPaquete { get; set; }

      //public EUnidadDeMedida unidadDeMedida { get; set; }
      /// <summary>
      /// vinculo entre categoria y producto
      /// </summary>
      /// <value></value>
      public int categoriaId { get; set; }
      /// <summary>
      /// Al momento de visualizar un objeto se obtiene de categoria
      /// </summary>
      /// <value></value>
      public Categoria categoria { get; set; }
    }
}