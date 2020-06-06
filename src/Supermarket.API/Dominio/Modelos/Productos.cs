namespace Supermarket.API.Dominio.Modelos
{

  /// <summary>
  /// En esta clase producto se alamcenan los productos que poseen un identificador un nombre una cantidad por paquete y una categoria a la cual pertenece para poder mejorar su busqueda
  /// </summary>
    public class Producto
    {
      /// <summary>
      /// Propiedad que funciona como identificador de cada producto
      /// </summary>
      /// <value></value>
      public int Id { get; set; }

      /// <summary>
      /// Esta propiedad me permite asignarle un valor de tipo string que funcionara para dar el nomre a cada producto
      /// </summary>
      /// <value></value>
      public string nombre { get; set; }
      
      /// <summary>
      /// Esta propiedad me permite saber cuanto productos hay por paquete para determinar precio por unidad supongo :D
      /// </summary>
      /// <value></value>

      public int cantidadxPaquete { get; set; }

      //public EUnidadDeMedida unidadDeMedida { get; set; }
      /// <summary>
      /// Conexion entre categoria y producto, categoriaId es la llave Foranea que permite recibir y dar informacion
      /// </summary>
      /// <value></value>
      public int categoriaId { get; set; }
      /// <summary>
      /// Al momento de requerir una vista de Id la saca de Categoria categoria :D
      /// </summary>
      /// <value></value>
      public Categoria categoria { get; set; }
    }
}