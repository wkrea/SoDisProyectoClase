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

        public CategoriaRepo(SupermarketApiContext apiContex)
        {
            /// <summary>
            /// Esta si se accede a la base 
            /// </summary>
            db = apiContex;
        }

        public async Task<Categoria> GetCatergoriaAsyncById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }

        public async Task<IEnumerable<Categoria>> GetCatergoriaAsync()
        {
           IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
           return lista;
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