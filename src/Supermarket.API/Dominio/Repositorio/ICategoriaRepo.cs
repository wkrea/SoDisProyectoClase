using System.Collections.Generic;
using System.Threading.Tasks;
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
        /// <summary>
        /// Obtiene la categoria
        /// </summary>
        /// <param name="id">Id Categoria</param>
        /// <returns></returns>
        IEnumerable<Categoria> GetCategorias();
        
        /// <summary>
        /// Secuencial asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        Categoria FindCategoriaById(int id);
    }
}