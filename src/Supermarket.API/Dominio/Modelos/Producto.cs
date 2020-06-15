namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        /// <summary>
        /// definician de las propiedades y estructuras de datos del modelo de la producto
        /// </summary>
        /// <value></value>
        public int id { get; set; }
        public string  nombre { get; set; }
        public int CantidadxPaquete { get; set; }
         //public EUnidadDeMedida UnidadDeMedida { get; set; }

        // llaves foraneas de categorias 
         public int CategoriaId { get; set; }
         public Categoria categoria { get; set; }
    }   
}