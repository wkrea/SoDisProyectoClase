namespace Supermarket.Api.Dominio.Modelos
{
    public class Producto
    {
        /// <summary>
        /// Clase correspondiente a la tabla productos, definicion de propiedades
        /// </summary>
        /// <value>Id, nombre</value>
        public int Id { get; set; }
        /// <summary>
        /// Identificador del producto
        /// </summary>
        /// <value>Id</value>
        public string nombre { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        /// <value>nombre</value>
        public int cantidadxpaquete { get; set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        /// <value>Cantidad productos</value>
        
        //public EUnidadDeMedida unidadDemedida { get; set; }
        public int categoriaId { get; set; }
        /// <summary>
        /// Propiedad para la relacion con Categoria
        /// </summary>
        /// <value>Id categoria</value>
        public Categoria categoria { get; set; }
        /// <summary>
        /// Para establecer la categoria, basado en la propiedad CategoriaId
        /// </summary>
        /// <value>Categoria</value>
    }
    
}