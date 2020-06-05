namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
      public int Id { get; set; }
      public string nombre { get; set; }
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