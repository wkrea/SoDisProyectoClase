using System.Collections.Generic;

namespace Supermarket.Api.Dominio.Modelos
{
    public class Categoria
    {
        /// <summary>
        /// Clase correspondiente a la tabla categoria
        /// </summary>
        /// <value></value>
        public int id { get; set; }
        public string nombre { get; set; }
        public IList<Producto> productos { get; set;} //Relacion entre categoria y productos

    
    }

}
