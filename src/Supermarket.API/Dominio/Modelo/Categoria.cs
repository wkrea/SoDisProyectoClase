using System.Collections.Generic;

/// <summary>
/// Espacio del proyecto
/// </summary>
namespace Supermarket.Api.Dominio.Modelos
{
    
    /// <summary>
    /// Clase correspondiente a la tabla categoria, definen la propiedades
    /// </summary>
    /// <value>Id, nombre</value>
    public class Categoria
    {
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        /// <value>id</value>
        public int id { get; set; }
        
        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        /// <value>nombre</value>
        public string nombre { get; set; }
        
        /// <summary>
        /// Permite establecer relacion entre Categoria y productos
        /// </summary>
        /// <value></value>
        public IList<Producto> productos { get; set;} 
        
    
    }

}
