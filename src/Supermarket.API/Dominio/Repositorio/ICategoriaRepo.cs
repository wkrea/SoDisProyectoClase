using System.Collections.Generic;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// clase interface 
        /// permite obtener la lista de categorias desde la base
        /// </summary>
        /// <returns></returns>
        IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Permite obtener la informacion de la cateogira asociada
        /// al identificador pasado por parametro
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        Categoria FindCategoriaById(int id);
    }
}