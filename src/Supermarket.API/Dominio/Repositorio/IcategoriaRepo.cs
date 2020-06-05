using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorio
{
    /// <summary>
    /// Interface para el repositorio de categorias, son los puntos de conexión desde donde extraigo o inyecto datos
    /// sólo se encarga de entregar los datos crudos que requiere el controlador para que él los devuelva en el formato que corresponda
    /// IcategoriaRepo permite obtener la lista de categorias desde la base
    /// </summary>
    public interface ICategoriaRepo
    {
            /// <summary>
            /// Permite obtener la lista de categorías desde la base
            /// </summary>
            /// <returns></returns>
            IEnumerable<Categoria> GetCategorias();
            /// <summary>
            /// Permite obtener la información de la categoría asociada al id=identificador pasado por parametro
            /// </summary>
            /// <param name="id de la categoria"></param>
            /// <returns></returns>
            IEnumerable<Categoria> FindCategoriaById(int id);
    }
}