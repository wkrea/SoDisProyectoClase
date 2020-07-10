using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Persistencia.Contexto;

namespace Supermarket.API.Persistencia.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categories.AddAsync(categoria);
        }

        public async Task<Categoria> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Categoria categoria)
        {
            _context.Categories.Update(categoria);
        }

        public void Remove(Categoria categoria)
        {
            _context.Categories.Remove(categoria);
        }
    }
}