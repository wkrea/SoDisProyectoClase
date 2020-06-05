namespace Supermarket.Api.Dominio.Modelos
{

    public class Producto
    {
        /// <summary>
        /// Clase correspondiente a la tabla productos
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        public string nombre { get; set; }
        public int cantidadxpaquete { get; set; }
        // public EUnidadDeMedida unidaddemedida { get; set; }

        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }
        
    
    }
    
}