using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Persistencia.Contexto;

namespace Supermarket.API.Persistencia.Repositorios
{
    public class ProductoRepositorio : BaseRepositorio, IProductoRepositorio
    {
        public ProductoRepositorio(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Producto>> ListAsync()
        {
            return await _context.Productos
                                 .Include(p => p.categoria)
                                 .ToListAsync();
        }

        public async Task<Producto> FindByIdAsync(int id)
        {
            // Consulta de maestro detalle empleando LinQ
            return await _context.Productos
                                 .Include(p => p.categoria)
                                 .FirstOrDefaultAsync(p => p.id == id); 
                                 // Como Incluir cambia el retorno del método, no podemos usar FindAsync
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public void Update(Producto producto)
        {
            _context.Productos.Update(producto);
        }

        public void Remove(Producto producto)
        {
            _context.Productos.Remove(producto);
        }
    }
}