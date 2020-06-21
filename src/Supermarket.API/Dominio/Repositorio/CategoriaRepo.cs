using System.Reflection.Metadata;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Persistencia;
using Supermarket.API.Dominio.Repositorios;
using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;
using System.Linq;
using System.Collections;
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

      public IEnumerable<Categoria> GetCategorias()
      {
        IEnumerable<Categoria> lista = db.categorias.ToList();
        return lista;
      }
      
      /// <summary>
      ///implementacion secuecial asincrona 
      /// </summary>
      ///<returns></returns>
      public async Task<Categoria> FindCategoriaById(int id)
      {
        Categoria resultado = await db.categorias.FindAsync(id);
        return resultado;
      }
      
      public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
      {
        IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
        return lista;
      }


      ///<summary>
      /// crear categoria
      /// </summary>
      ///<param name = "categoria"></param>
      public void crearCategoria(Categoria categoria)
      {
        db.categorias.AddAsync(categoria);
      }

      /// <summary>
      /// editar las categorias
      /// </summary>
      /// <param name = "id"></param>
      /// <param name = "categoria">id categoria</param>
      public void editarCategoria(int id, Categoria categoria)
      {
        db.Entry(categoria).State = EntityState.Modified;
        db.categorias.Update(categoria);
      }

      /// <summary>
      /// editar las categorias
      /// </summary>
      /// <param name = "id"></param>
      /// <param name = "categoria">id categoria</param>
      public void eliminarCategoria(Categoria categoria)
      {
        db.categorias.Remove(categoria);
      }

       /// <summary>
      /// editar las categorias
      /// </summary>
      /// <param name = "categorias"></param>
      /// <returns></returns>
      public async Task<Categoria> guardarCategoria(Categoria categoria)
      {
        await db.SaveChangesAsync();
        return categoria;
      }

    // public Task<IEnumerable<Categoria>> GetCategoriaAsync()
    // {
    //   throw new System.NotImplementedException();
    // }
  }
}