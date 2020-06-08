using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IList<Producto> Productos { get; set; } = new List<Producto>();
    }
}
