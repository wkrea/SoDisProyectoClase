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
        Task<Categoria> GetCategoriasAsyncById( int id );

        /// <summary>
        /// Interface que nos permite crear una nueva categoria en la base de datos 
        /// </summary>
        /// <param name="categoria">entidad con los datos nuevos</param>
        void crearCategoria( Categoria categoria );

        /// <summary>
        /// interface que nos permite editar una categoria existente en la base de datos 
        /// </summary>
        /// <param name="id">id del eslemento que se desea modoficar</param>
        /// <param name="categoria">entidad que tendra los nuevos registros</param>
        void editarCategoria( int id, Categoria categoria );

        /// <summary>
        /// interface que nos permite eliminar una categoria existente en la base de datos
        /// se pasa categoria para hacer validaciones 
        /// </summary>
        /// <param name="categoria">Entidad que queremos eliminar de la base</param>
        void eliminarCategoria( Categoria categoria );

        /// <summary>
        /// interface que nos permite guardar de forma asincrona nuevas categorias 
        /// </summary>
        /// <param name="categoria">Entidad que queremos guardar en la base</param>
        /// <returns></returns>
        Task<Categoria> guardarCategoria( Categoria categoria );
    }
}