using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Interface que nos permite optener la lista de las categorias de la base de datos
        /// </summary>
        /// <returns>Retorna una lista de catagorias de la base de datos</returns>
        IEnumerable<Categoria> GetCategorias();

        /// <summary>
        /// Interface que nos permite tener infirmacion de la cartegoria asociada al 
        /// identificador pasado por parametro 
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        IEnumerable<Categoria> FindCategoriasById( int id );
    }
}