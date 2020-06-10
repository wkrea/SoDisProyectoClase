using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Interface para el repositorio de categorias, son los puntos de conexión desde donde extraigo o inyecto datos
    /// sólo se encarga de entregar los datos crudos que requiere el controlador para que él los devuelva en el formato que corresponda
    /// IcategoriaRepo permite obtener la lista de categorias desde la base
    /// </summary>
    public interface ICategoriaRepo
    {
            /// <summary>
            /// Método sincrono         
            /// /// Permite obtener la lista de categorías desde la base
            /// </summary>
            IEnumerable<Categoria> GetCategorias();

            /// <summary>
            /// Permite obtener la información de la categoría asociada al id=identificador pasado por parametro
            /// Método Asincrono
            /// </summary>
            /// <param name="id"> de la categoria></param>
            /// <returns></returns>
            Task<IEnumerable<Categoria>> GetCategoriasAsync();
            /// <summary>
            /// Permite obtener la información de la categoría asociada al id=identificador pasado por parametro
            /// Identificador pasado por parametro
            /// </summary>
            Categoria FindCategoriaById(int id);
    }
}