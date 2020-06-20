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
        public CategoriaRepo(SupermarketApiContext apiContext)
        {
            /// Acceso a toda la base de datos 
            db = apiContext;
        }
        /// <summary>
        /// Implementación secuencial sincrona
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            //Accedo a los datos de las categorias, extraigo la lista y
            //la guardo en una variable llamamos Lista la cual retornamos
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }
        /// <summary>
        /// Implementación secuencial Asincrona
        /// </summary>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }
        /// <summary>
        /// Metodo que encuentrala categiróa dado un Id, la tarea se hace de forma asincrona 
        /// </summary>
        public async Task<Categoria> FindCategoriaById(int id)
        {
            /// utilizo el metodo del apiContext DbSet, le pasamos el id y él lo busca en la BD
            return await db.categorias.FindAsync(id);
        }
    }
}