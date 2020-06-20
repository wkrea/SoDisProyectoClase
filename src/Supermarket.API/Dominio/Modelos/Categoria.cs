using System.Collections.Generic;
namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria
    {
        /// <summary>
        /// Variable Id de la Categoria
        /// </summary>
        /// <value></value>
        public int id { get; set;}
        /// <summary>
        /// Variable que contiene el nombre de la categoria
        /// </summary>
        /// <value></value>
        public string nombre {get; set;}
        /// <summary>
        /// relacion entre tablas {Categoria y productos}
        /// </summary>
        /// <value></value>
         public IList<Producto>  productos{ get; set;}
    }
}