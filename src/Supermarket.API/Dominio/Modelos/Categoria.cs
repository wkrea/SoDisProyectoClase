using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Se crera clase que va a contener el id, nombre de la categoría
    /// junto con una lista que despliega los productos de la categoría seleccionada
    /// </summary>

    public class Categoria
    {
        //Identificador de la categoria
        public int id { get; set; }

        //Nombre de la categoria
        public string nombre { get; set; }

        //Lista de productos por categoría (Relación)
        public IList<Producto> producto { get; set; }
    }
}