using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Dominio.Recursos
{
    public class SaveCategoriaRecurso
    {
        [Required]
        [MaxLength(30)]
        public string nombre { get; set; }
    }
}