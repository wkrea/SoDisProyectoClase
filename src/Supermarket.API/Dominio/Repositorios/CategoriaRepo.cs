using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Dominio.Repositorios
{
    public class CategoriaRepo : ICategoriaRepo
    {
        private readonly SupermarketApiContext db;
        //constructor

        public CategoriaRepo(SupermarketApiContext apiContext)
        {
            //acceso a la db
            db=apiContext;
        }
        //relaciona categoria repo con la interfaz y la inferfacz con su controlador 
        /// <summary>
        /// Implementacion secuencial sincrona
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategoria()
        {
            //crea una lista  de las categorias
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }
            /// <summary>
            /// Implementacion secuencial asincrona
            /// </summary>
            /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }


        public async Task<Categoria> GetCategoriaAsyncById(int id)
        {

           Categoria resultado= await db.categorias.FindAsync(id);
           return resultado;
        }

        public  void crearCategoria(Categoria categoria)
        {
             db.categorias.AddAsync(categoria);
        }

        public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.categorias.Update(categoria);
        }

        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }

        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }
    }
}