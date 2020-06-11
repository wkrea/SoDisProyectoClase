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
        /* <summary>
        ///Implementacion secuencial sincrona
        /// </summary> 
       public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista=db.categorias.ToList();
           return lista;
        }*/
        public Categoria FindCategoria(int id)
        {
            throw new System.NotImplementedException();
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