using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Defino la clase Productos y sus propiedades
    /// CantidadxPaquete: cantidad del producto por paquete
    /// </summary>
    public class Producto
    {
        /// id: identificiador del producto
        [Key]
        public int id {get; set;}
        /// nombre: nombre del producto
        [Required]
        public string nombre {get; set;}
        public int cantidadxPaquete{get; set;}
        /// CategoriaId: Identificador de la categoría a la que pertenece
        public int categoriaId{get; set;}
        public Categoria categoria{get; set;}
    }
}