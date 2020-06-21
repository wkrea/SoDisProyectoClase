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
        /* IEnumerable<Categoria> GetCategorias(); */
        
        /// <summary>
        /// Secuencial asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        /// <summary>
        /// Obtiene categoria por id
        /// </summary>
        /// <param name="id">id categoria</param>
        /// <returns></returns>
        Task<Categoria> FindCategoriaById(int id);

        /// <summary>
        /// Crear categoria
        /// </summary>
        /// <param name="categoria"></param>
        void crearCategoria(Categoria categoria);

        /// <summary>
        /// Edita categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        void editarCategoria(int id, Categoria categoria);

        /// <summary>
        /// Elimina la categoria
        /// </summary>
        /// <param name="categoria"></param>
        void eliminarCategoria(Categoria categoria);

        /// <summary>
        /// Guarda la categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        Task<Categoria> guardarCategoria(Categoria categoria);
    }
}