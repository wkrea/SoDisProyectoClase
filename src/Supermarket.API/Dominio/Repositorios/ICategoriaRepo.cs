using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Interface que nos permite optener la lista de las categorias de la base de datos
        /// metodo secuencial
        /// </summary>
        /// <returns>Retorna una lista de catagorias de la base de datos</returns>
        // IEnumerable<Categoria> GetCategorias();

        /// <summary>
        /// Interface que nos permite optener la lista de las categorias de la base de datos
        /// metodo Asincrono --> usa paralelismo en el servidor
        /// </summary>
        /// <returns>Retorna una lista de catagorias de la base de datos</returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        /// <summary>
        /// Interface que nos permite tener infirmacion de la cartegoria asociada al 
        /// identificador pasado por parametro 
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        Task<Categoria> FindCategoriasById( int id );
    }
}