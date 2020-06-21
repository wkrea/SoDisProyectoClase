using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// clase interface 
    /// Metodo sincrono
    /// permite obtener la lista de categorias desde la base
    /// </summary>
    /// <returns></returns>
    public interface ICategoriaRepo
    {
        
        /* IEnumerable<Categoria> GetCategorias(); */
        
        
        /// <summary>
        /// Metodo asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        /// <summary>
        /// Permite obtener la informacion de la categoria
        /// asociada al identificador (asincrono)
        /// </summary>
        /// <param name="id">identificador de categoria</param>
        /// <returns></returns>
        Task<Categoria> FindCategoriaById(int id);


        /// <summary>
        /// crear categoria
        /// </summary>
        /// <param name="categoria">categoria nueva</param>
        void crearCategoria(Categoria categoria);

        /// <summary>
        /// edita la categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria">id de la categoria</param>
        void editarCategoria(int id, Categoria categoria);

        /// <summary>
        /// Elimina categoria
        /// </summary>
        /// <param name="categoria">Categoria</param>
        void eliminarCategoria(Categoria categoria);

        /// <summary>
        /// Guarda categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        Task<Categoria> guardarCategoria(Categoria categoria);
    }
}