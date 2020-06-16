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
        public CategoriaRepo(SupermarketApiContext apiContext)
        {
            db = apiContext;
        }

        // /// <summary>
        // /// Implementación secuencial Sincrona
        // /// </summary>
        // /// <returns></returns>
        // public IEnumerable<Categoria> GetCategorias()
        // {
        //     IEnumerable<Categoria> lista = db.categorias.ToList();
        //     return lista;
        // }

        /// <summary>
        /// Implementación secuencial Asíncrona
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }
        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }
    }
}