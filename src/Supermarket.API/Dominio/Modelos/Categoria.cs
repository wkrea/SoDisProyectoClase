using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Se crera clase que va a contener el id, nombre de la categoría
    /// junto con una lista que despliega los productos de la categoría seleccionada
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificador de la categoria
        /// </summary>
        /// <value></value>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la categoria
        /// </summary>
        /// <value></value>
        public string nombre { get; set; }

        /// <summary>
        /// Lista de productos por categoría (Relación)
        /// </summary>
        /// <value></value>
        public IList<Producto> producto { get; set; }

    }
}