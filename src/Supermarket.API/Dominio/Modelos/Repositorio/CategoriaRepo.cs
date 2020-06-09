using System.Security.AccessControl;
using System.Reflection.Metadata;

namespace Supermarket.API.Dominio.Repositorio
{
  public class CategoriaRepo
  {
    public class CategoriaRepo : ICategoriaRepo
    {

      private readonly SupermarketApiContext db;
      public CategoriaRepo(SupermarketApiContext apiContext)
      {
        db = apiContext;
      }
      public IEnumerable<Categoria> GetCategorias()
      {
        IEnumerable<Categoria> lista = db.categorias.ToList();
        return lista;
        ///throw new System.NotImplementedException();

      }
      public Categoria FindCategoriaById(int id)
      {
        throw new System.NotImplementedException();
      }
      
    }
  }
}