using System.Reflection.Metadata;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Persistencia;
using Supermarket.API.Dominio.Repositorios;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Supermarket.API.Dominio.Repositorios
{
  public class CategoriaRepo : ICategoriaRepo
  {
    private readonly SupermarketApiContext db;

      public CategoriaRepo(SupermarketApiContext apiContext)
      {
        db = apiContext;
      }
      public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
      {
        IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
        return lista;
      }
      public Categoria FindCategoriaById(int id)
      {
        throw new System.NotImplementedException();
      }
  }
}