using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// clase interface 
        /// Metodo sincrono
        /// permite obtener la lista de categorias desde la base
        /// </summary>
        /// <returns></returns>
        IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Permite obtener la informacion de la cateogira asociada
        /// al identificador pasado por parametro
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        
        /// <summary>
        /// Metodo asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Categoria FindCategoriaById(int id);
    }
}