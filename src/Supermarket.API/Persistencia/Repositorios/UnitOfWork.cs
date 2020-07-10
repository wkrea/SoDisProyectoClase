using System.Threading.Tasks;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Persistencia.Contexto;

namespace Supermarket.API.Persistencia.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}