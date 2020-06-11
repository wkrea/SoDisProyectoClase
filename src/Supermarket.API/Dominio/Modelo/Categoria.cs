using System.Collections.Generic;

namespace Supermarket.Api.Dominio.Modelos
{
    /// <summary>
    /// Clase de la tabla categoria
    /// </summary>
    /// <value></value>
    public class Categoria
    {
        /// <summary>
        /// Id de la categoria
        /// </summary>
        /// <value>id</value>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        /// <value>nombre</value>
        public string nombre { get; set; }
        
        /// <summary>
        /// relacion entre Categoria y productos
        /// </summary>
        /// <value></value>
        public IList<Producto> productos { get; set;} 
        

    
    }

}
