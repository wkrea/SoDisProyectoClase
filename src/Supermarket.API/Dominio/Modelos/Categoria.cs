using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Esta clase permite la asignacion de categorias a los productos
    /// Adoptando relacion entre Categorias y productos
    /// </summary>
    public class Categoria
    {
        internal int id;
        internal string nombre;
        /// <summary>
        /// Propiedad de identificador con sus metodos de acceso para las categorias
        /// </summary>
        /// <value></value>
        public int Id {get; set;}
        /// <summary>
        /// Propiedad Nombre con sus metodos de acceso para las categorias
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Relacion entre categoria y productos 
        /// </summary>
        /// <value></value>   
        public IList<Producto> productos {get; set;}  
    }
}