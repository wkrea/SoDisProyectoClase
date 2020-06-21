using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Persistencia;

namespace Supermarket.API.Dominio.Repositorios
{
    /// <summary>
    /// Implementa la interfaz ICategoriaRepo
    /// </summary>
    public class CategoriaRepo : ICategoriaRepo
    {
        #region atributos, campos y/o variables
        private readonly SupermarketApiContext db;

        #endregion

        #region constructor
        public CategoriaRepo(SupermarketApiContext context)
        {
            db = context;
        }
        #endregion

        #region metodos
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await db.categorias.ToListAsync();
        }

        public async Task<Categoria> HallarCategoriaById(int id)
        {
            // return await db.categorias.FindAsync(id);
            return await db.categorias.FirstOrDefaultAsync(c => c.id.Equals(id));
        }
        #endregion

        public void crearCategoria(Categoria categoria)
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

        public async Task<Categoria> guardarCategoriaById(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }
    }
}