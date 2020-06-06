namespace Supermarket.API.Dominio.Modelos
{
    public class Producto 
    {
        /// <summary>
        /// Contiene el id del producto
        /// </summary>
        /// <value></value>
        public int id { get; set;}
        /// <summary>
        /// Contiene el nombre del producto
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Contiene la cantidad de producto
        /// </summary>
        /// <value></value>
        public int CantidadxPaquete {get; set;}
        //public EUnidadDeMedida unidadDeMedida {get; set;}
        /// <summary>
        /// Contiene el Id de la categoria a la que pertenece el producto
        /// </summary>
        /// <value></value>
        public int categoriaId {get; set;}
        /// <summary>
        /// Contiene la Categoria del producto
        /// </summary>
        /// <value></value>
        public Categoria categoria {get; set;}
    }
}