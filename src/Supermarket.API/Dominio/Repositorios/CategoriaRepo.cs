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

        /// <summary>
        /// Constructor de la clase CategoriaRepo
        /// </summary>
        public CategoriaRepo(SupermarketApiContext apicontext)
        {
            db = apicontext;
        }

        public void crearCategoria(Categoria categoria)
        {
            db.categorias.AddAsync(categoria);
        }

        public void editarCategoria(Categoria categoria)
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


        /// <summary>
        /// Metodo Asincrono
        /// Devuelve lista de Categorias
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }

        public async Task<Categoria> GetCategoriasAsyncById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }

    }
}