using Supermarket.API.Persistencia.Contexto;

namespace Supermarket.API.Persistencia.Repositorios
{
    public abstract class BaseRepositorio
    {
        protected readonly AppDbContext _context;

        public BaseRepositorio(AppDbContext context)
        {
            _context = context;
        }
    }
}