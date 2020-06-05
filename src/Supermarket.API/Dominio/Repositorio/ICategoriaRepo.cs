using System.Collections.Generic;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// clase que retorna una interface
    /// Obtiene la lista de categorias desde la base
    /// </summary>
    /// <returns></returns>
    public interface ICategoriaRepo
    {
        IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Obtiene la categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Categoria FindCategoriaById(int id);
    }
}