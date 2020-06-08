using System.Collections.Generic;
using System.Threading.Tasks;

using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Interfaz (Api Contract)
    /// Permite definir los métodos que permitiran acceder la lógica de negocio
    /// Aislando la capa de acceso a datos de los demás módulos que consumen los
    /// datos
    /// </summary>
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Permite obtener la lista de categorias de forma asincrona
        /// async y await
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Categoria>> ListAsync();
    }
}