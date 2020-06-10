namespace Supermarket.API.Dominio.Modelos
{    
    /// <summary>
    /// Esta clase permite relacionar varios productos a una misma categoria
    /// Adoptando relacion entre Categorias y productos
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Propiedad de identificador con sus metodos de acceso para los productos
        /// </summary>
        /// <value></value>
        public int Id {get; set;}
        /// <summary>
        /// Propiedad Nombre con sus metodos de acceso para los productos
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        public int cantidasxPaquete {get; set;}       
        /// <summary>
        /// Relacion que permite establecer conexion entre las dos entidades
        /// </summary>
        /// <value></value>
        public int categoriaId {get; set;}
        public Categoria categoria {get; set;}        
    }
}