using System.Collections.Generic;

namespace Supermarket.API.Dominio.Entidades
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public IList<Producto> productos { get; set; } = new List<Producto>();
    }
}