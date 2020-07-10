using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Servicios.Responses;

namespace Supermarket.API.Dominio.Servicios
{
    public interface IProductoServicio
    {
        Task<IEnumerable<Producto>> ListAsync();
        Task<ProductoResponse> SaveAsync(Producto producto);
        Task<ProductoResponse> UpdateAsync(int id, Producto producto);
        Task<ProductoResponse> DeleteAsync(int id);
    }
}