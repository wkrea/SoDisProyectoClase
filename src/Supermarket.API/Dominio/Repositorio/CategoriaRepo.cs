using System.Reflection.Metadata;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Persistencia;
using Supermarket.API.Dominio.Repositorios;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Dominio.Repositorios
{
  public class CategoriaRepo : ICategoriaRepo
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
      public async Task<Categoria> FindCategoriaById(int id)
      {
        Categoria resultado = await db.categorias.FindAsync(id);
        return resultado;
      }

    // public Task<IEnumerable<Categoria>> GetCategoriaAsync()
    // {
    //   throw new System.NotImplementedException();
    // }
  }
}