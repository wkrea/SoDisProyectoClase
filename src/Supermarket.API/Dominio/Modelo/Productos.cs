using System.ComponentModel.DataAnnotations.Schema;
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
	//public EUnidadDeMedida unidadDeMedida { get; set; }
	
	public int categoriaId { get; set; }
	public Categoria categoria { get; set; }
	
	}
}
