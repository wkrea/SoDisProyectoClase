using System.Collections.Generic;

namespace Supermarket.Api.Dominio.Modelos
{
    /// <summary>
    /// Espacio del proyecto
    /// </summary>

    public class Categoria
    {
        /// <summary>
        /// Clase correspondiente a la tabla categoria, definen la propiedades
        /// </summary>
        /// <value>Id, nombre</value>
        public int id { get; set; }
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        /// <value>id</value>

        public string nombre { get; set; }
        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        /// <value>nombre</value>

        public IList<Producto> productos { get; set;} 
        /// <summary>
        /// Permite establecer relacion entre Categoria y productos
        /// </summary>
        /// <value></value>
    
    }

}
