using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// definician de las propiedades y estructuras de datos del modelo de la categoria 
    /// </summary>
    public class Categoria
    {
        public int id { get; set; }
        public string  nombre { get; set; }
        public IList<Producto> productos { get; set; }   //Relacion entre tablas (categorias y productos)
    }
}
