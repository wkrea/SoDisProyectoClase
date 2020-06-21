using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Se crera clase que va a contener el id, nombre del producto
    /// que se listarán dentro de categoría
    /// </summary>
    public class Producto
    {
        //Identificador del producto
        public int id { get; set; }

        //Nombre del producto
        public string nombre { get; set; }

        //Cantidad de productos
        public int cantidadPaquete { get; set; }

        //Identificador de la categoria
        public int categoriaId { get; set; }

        //Nombre de la categoria
        public int categoria { get; set; }
    }
}