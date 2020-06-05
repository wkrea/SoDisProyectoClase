using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
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