using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Metodo sincrono (secuencial)
        /// Permite obtener la lista de categorias desde la base
        /// </summary>
        /// <returns></returns>
        //IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Metodo Asincrono
        /// Permite obtener la lista de categorias desde la base
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        /// <summary>
        /// Permite obtener la informacion de la categoria asociada al identificador 
        /// pasado por parametro de manera asincrona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Categoria> GetCategoriasAsyncById(int id);
        /// <summary>
        /// Metodo para ejecutar la creacion de categorias en el CRUD
        /// </summary>
        /// <param name="categoria"></param>
        void crearCategoria(Categoria categoria);
        /// <summary>
        /// Metodo para ejecutar la modificacion de categorias en el CRUD
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        void editarCategoria(int id, Categoria categoria);
        /// <summary>
        /// Metodo para ejecutar la eliminacion de categorias en el CRUD
        /// </summary>
        /// <param name="categoria"></param>
        void eliminarCategoria(Categoria categoria);
        /// <summary>
        /// Metodo para ejecutar el guardado de los cambios aplicados a categorias en el CRUD
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        Task<Categoria> guardarCategoria(Categoria categoria);

    }
}