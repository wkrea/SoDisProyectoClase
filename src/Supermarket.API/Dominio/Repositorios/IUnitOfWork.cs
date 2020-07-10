using System.Threading.Tasks;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}