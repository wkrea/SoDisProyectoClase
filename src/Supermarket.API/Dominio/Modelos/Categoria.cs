using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    public class Categoria
    {   
       /// <summary>
        /// Definicion de atributos dentro de la clase de Categoria 
        /// </summary> 
        public int id {get; set;}
       /// <summary>
        ///representa el identificador unico de la categoria
        /// </summary> 
        public string nombre {get; set;}
        /// <summary>
        ///corresponde al nombre de la categoria
        /// </summary> 
        public IList<Producto> productos {get; set;}        
        /// <summary>
        ///Relacion entre tablas (categorias y productos)
        /// </summary>   
    }
}