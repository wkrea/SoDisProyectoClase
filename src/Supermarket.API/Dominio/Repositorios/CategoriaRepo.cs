using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;

namespace Supermarket.API.Dominio.Repositorios
{
   public class CategoriaRepo : ICategoriaRepo
   {
       private readonly SupermarketApiContext db;
       public CategoriaRepo(SupermarketApiContext apiContext ){
            db=apiContext;
       }
    //     ///<summary>
    //     ///Implementacion secuencial sincrona
    //     /// </summary> 
    //    public IEnumerable<Categoria> GetCategorias()
    //     {
    //         IEnumerable<Categoria> lista=db.categorias.ToList();
    //        return lista;
    //     }
        ///<summary>
        ///Implementacion secuencial asincrona metodo FindCategoriaById que encuentra una categoria
        /// </summary> 
        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado=await db.categorias.FindAsync(id);
            return resultado;
        } 
      /// <summary>
        ///Implementacion secuencial Asincrona
        /// </summary> 
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
              IEnumerable<Categoria> lista=await db.categorias.ToListAsync();
           return lista;
        }
    } 
}