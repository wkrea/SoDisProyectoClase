using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// definician de las propiedades y estructuras de datos del modelo de la producto
    /// </summary>
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string  nombre { get; set; }
        public int CantidadxPaquete { get; set; }
         //public EUnidadDeMedida UnidadDeMedida { get; set; }

        // llaves foraneas de categorias 
         public int CategoriaId { get; set; }
         public Categoria categoria { get; set; }
    }   
}