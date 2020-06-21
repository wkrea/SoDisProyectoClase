using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria{
        public int id { get; set; }
        public string nombre { get; set; }
        
        /// <summary>
        /// Relacion entre tablas (categoria y producto)
        /// </summary>
        /// <value></value>
        public IList<Producto> productos { get; set; }    

    }
}