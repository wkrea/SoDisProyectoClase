using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Servicios.Responses;

namespace Supermarket.API.Dominio.Servicios
{
    public interface ICategoriaServicio
    {
         Task<IEnumerable<Categoria>> ListAsync();
         Task<CategoriaResponse> SaveAsync(Categoria categoria);
         Task<CategoriaResponse> UpdateAsync(int id, Categoria categoria);
         Task<CategoriaResponse> DeleteAsync(int id);
    }
}