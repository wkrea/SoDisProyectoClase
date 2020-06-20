using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Interface de conexión para el repositorio de categorias, son los puntos de conexión desde donde extraigo o inyecto datos
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
            /// Permite buscar la información de la categoría asociada al id:Identificador pasado por parametro
            /// </summary>
            /// Debo recordar que como es la interface de conexión los cambios asincronos se deben hacer tambien en el repo
            Task<Categoria> FindCategoriaById(int id);
    }
}