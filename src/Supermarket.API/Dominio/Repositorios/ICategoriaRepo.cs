using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        ///Metodo Sincrono
        ///  Devuelve la lista de categorias desde la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Categoria> GetCategorias();

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
        Categoria FindCategoriaById(int id);
    }
}