
using System.Threading.Tasks;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <sumary>
    ///Permire definir los métodos que permitirán acceder la lógica de negocio
    ///aislando la capa de acceso a datos de los demás módulos con consuman los datos.
    /// </sumary>
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Permite obtener lista categorias/Metodo Asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        /// <summary>
        /// Devuelve al info de la categoria asociada al identificador
        /// pasado por el parametro
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        Task<Categoria> GetCategoriasAsyncById(int id);

        /// <summary>
        /// Metodo que permite la creacion de una categoria, recibe como parametro una instancia de tipo Categoria
        /// </summary>
        /// <param name="categoria"></param>
        void crearCategoria(Categoria categoria);
        /// <summary>
        /// Metodo para editar una categoria, recibe una Categoria como parametro
        /// </summary>
        /// <param name="categoria"></param>
        void editarCategoria(Categoria categoria);
        /// <summary>
        /// Metodo de eliminacion de una categoria, Recibe una instancia de
        /// tipo Categoria como parametro
        /// </summary>
        /// <param name="categoria"></param>
        void eliminarCategoria(Categoria categoria);

        Task<Categoria> guardarCategoria(Categoria categoria);
    }
}