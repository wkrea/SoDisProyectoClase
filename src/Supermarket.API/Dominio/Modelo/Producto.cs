using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Api.Dominio.Modelos
{
    /// <summary>
    /// Clase de la tabla productos
    /// </summary>
    /// <value></value>
    public class Producto
    {
        [Key]

        /// <summary>
        /// Id producto
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        
        [Required]

        /// <summary>
        /// Nombre del producto
        /// </summary>
        /// <value></value>
        public string nombre { get; set; }
        
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        /// <value></value>
        public int cantidadxpaquete { get; set; }
        
        //public EUnidadDeMedida unidadDemedida { get; set; }
        
        /// <summary>
        /// relacion con Categoria
        /// </summary>
        /// <value>Id categoria</value>
        public int categoriaId { get; set; }
        
        /// <summary>
        /// basado en la propiedad CategoriaId
        /// </summary>
        /// <value></value>
        public Categoria categoria { get; set; }
        
        
    
    }
    
}