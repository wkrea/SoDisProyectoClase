using System.Reflection.Metadata;
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
        public CategoriaRepo (SupermarketApiContext apiContext)
        {
            db= apiContext;
        }
        /// <summary>
        /// Definicion de interfaz para el metodo de crear nueva categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public void crearCategoria(Categoria categoria)
        {
            db.categorias.AddAsync(categoria);
        }
        /// <summary>
        /// Definicion de interfaz para el metodo de modificar categorias
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.categorias.Update(categoria);
        }
        /// <summary>
        /// Definicion de interfaz para el metodo de eliminar categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }
        /// <summary>
        /// Metodo asincrono que espera que se haya terminado el guardado y retornara la categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }
        /// <summary>
        /// Implementacion secuencial sincrona
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }
        /// <summary>
        /// Implementacion secuencial Asincrona
        /// </summary>
        /// <returns></returns>        
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }
        /// <summary>
        /// Implementacion del metodo de manera secuencial asincrona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Categoria> GetCategoriasAsyncById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }
    }
}