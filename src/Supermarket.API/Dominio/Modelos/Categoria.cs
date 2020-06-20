using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public IList<Producto> producto {get; set;} // Relacion entre tablas de muchos a uno
    }
}