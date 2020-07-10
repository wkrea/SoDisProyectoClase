using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Dominio.Recursos
{
    public class SaveProductoRecurso
    {
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; }

        [Required]
        [Range(0, 100)]
        public short cantXpaquete { get; set; }

        [Required]
        [Range(1, 5)]
        public int unidadDMedida { get; set; } // AutoMapper is going to cast it to the respective enum value
        
        [Required]
        public int categoriaId { get; set; }
    }
}