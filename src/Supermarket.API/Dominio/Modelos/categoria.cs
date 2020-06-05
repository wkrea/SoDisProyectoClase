using System.Collections.Generic;
namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Defino la clase Categoría y sus propiedades
    /// </summary>
    public class Categoria
    {
        // id: identificiador de la categoría
        public int id{get; set;}
        // nombre: nombre de la categoría
        public string nombre {get; set;}
        // productos: relación entre la tabla categoría y porductos
        public IList<Producto> productos{get; set;} //Relación entre tablas (categoría y productos)
    }
}