using System.Collections.Generic;
namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Defino la clase Categoría y sus propiedades
    /// id: identificiador de la categoría
    /// nombre: nombre de la categoría
    /// productos: relación entre la tabla categoría y porductos
    /// </summary>
    public class Categoria
    {
        public int id{get; set;}
        public string nombre {get; set;}
        public IList<Producto> productos{get; set;} //Relación entre tablas (categoría y productos)
    }
}