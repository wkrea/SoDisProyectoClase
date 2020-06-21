using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Api.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;


namespace Supermarket.API.Dominio.Repositorios
{
    public class CategoriaRepo : ICategoriaRepo
    {
         
        private readonly SupermarketApiContext db;
        public CategoriaRepo(SupermarketApiContext apiContex)
        {
            db = apiContex;
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
        /// Metodo secuencial asincrono
        /// busca categorias segun id
        /// </summary>
        /// <param name="id">identificador categoria</param>
        /// <returns></returns>
        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
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

        /// <summary>
        /// crear categoria
        /// </summary>
        /// <param name="categoria"></param>
        public  void crearCategoria(Categoria categoria)
        {
             db.categorias.AddAsync(categoria);
        }

        /// <summary>
        /// Edita las categorias
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria">id categoria</param>
        public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.categorias.Update(categoria);
        }

        /// <summary>
        /// Elimina categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }

        /// <summary>
        /// Guarda la categoria creada
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }
    }

}