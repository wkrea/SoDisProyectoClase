using System.Collections.Generic;
using System.Linq;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;
using Supermarket.API.Dominio.Repositorio;
using System.Threading;
using System.Threading.Tasks;

namespace Supermarket.API.Dominio.Repositorios
{

    public class  CategoriaRepo : ICategoriaRepo
    
    {

      private readonly SupermarketApiContext db;

      public CategoriaRepo(SupermarketApiContext apiContext)
      {
          //db es una variable se puede llamar como querramos
        db = apiContext;

      }
      /// <summary>
      ///implementacion secuecial sincrona 
      /// </summary>
      ///<returns></returns>

      //public IEnumerable<Categoria> GetCategorias()
      //{
       // IEnumerable<Categoria> lista = db.categorias.ToList();
        //return lista;
      //}
      
      /// <summary>
      ///implementacion secuecial asincrona 
      /// </summary>
      ///<returns></returns>
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