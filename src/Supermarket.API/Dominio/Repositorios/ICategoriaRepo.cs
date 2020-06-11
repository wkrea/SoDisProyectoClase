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
        IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Metodo Asincrono
        /// Permite obtener la lista de categorias desde la base
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        /// <summary>
        /// Permite obtener la informacion de la categoria asociada al identificador pasado por parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Categoria FindCategoriaById(int id);
    }
}