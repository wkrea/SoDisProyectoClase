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
        
        IEnumerable<Categoria> GetCategorias();
        
        
        /// <summary>
        /// Metodo asincrono
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        
        Categoria FindCategoriaById(int id);
    }
}