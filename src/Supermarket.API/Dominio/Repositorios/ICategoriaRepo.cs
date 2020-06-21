using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Metodo Sincrono    
        /// Obtiene lista de categorias de la db
        /// </summary>
        /// <returns></returns>
        
        //IEnumerable<Categoria> GetCategoria();

        /// <summary>
        /// Metodo Asincrono
        /// Obtiene lista de categorias de la db
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        /// <summary>
        /// Informacion de la categoria por pId
        /// </summary>
        /// <param name="id">Identificador de la Categoria</param>
        /// <returns></returns>
        Task<Categoria> GetCategoriaAsyncById(int id);

        void crearCategoria(Categoria categoria);
        void editarCategoria(int id, Categoria categoria);
        void eliminarCategoria(Categoria categoria);

        Task<Categoria> guardarCategoria(Categoria categoria);
         

    }
}