using System.ComponentModel.DataAnnotations;
namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public int cantidadxPaquete { get; set; }

        //propiedad numerable
        //public EUnidadDeMedida unidadDeMedida { get; set; }

        //Propiedades que permiten Relacion entre las entidades
        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }
    }

} 