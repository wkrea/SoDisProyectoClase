namespace Supermarket.Api.Dominio.Modelos
{
    /// <summary>
    /// Clase de la tabla productos
    /// </summary>
    /// <value></value>
    public class Producto
    {
        
        public int Id { get; set; }
        /// <summary>
        /// Id producto
        /// </summary>
        /// <value></value>

        public string nombre { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        /// <value></value>

        public int cantidadxpaquete { get; set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        /// <value></value>
        
        //public EUnidadDeMedida unidadDemedida { get; set; }
        public int categoriaId { get; set; }
        /// <summary>
        /// relacion con Categoria
        /// </summary>
        /// <value></value>

        public Categoria categoria { get; set; }
        /// <summary>
        /// basado en la propiedad CategoriaId
        /// </summary>
        /// <value></value>
        
    
    }
    
}