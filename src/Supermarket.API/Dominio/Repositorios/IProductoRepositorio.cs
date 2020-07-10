using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> ListAsync();
        Task AddAsync(Producto producto);
        Task<Producto> FindByIdAsync(int id);
        void Update(Producto producto);
        void Remove(Producto producto);
    }
}