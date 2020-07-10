using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Interfaz (Api Contract)
    /// Permite definir los métodos que permitiran acceder la lógica de negocio
    /// Aislando la capa de acceso a datos de los demás módulos que consumen los
    /// datos
    /// </summary>
    public interface ICategoriaRepositorio
    {
        /// <summary>
        /// Método Asíncrono
        /// Permite obtener la lista de categorías desde la base 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> ListAsync();
        /// <summary>
        /// Permite obtener la información de la categoría asociada al 
        /// identificador pasado por parametro
        /// </summary>
        /// <param name="id">Identificador de la categoría</param>
        /// <returns></returns>
        Task<Categoria> FindByIdAsync(int id);

        Task AddAsync(Categoria categoria);
        void Update(Categoria categoria);
        void Remove(Categoria categoria);
    }
}