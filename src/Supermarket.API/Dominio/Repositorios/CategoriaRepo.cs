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

        /// <summary>
        /// Excepcion de FinsCategoriaById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        /// <summary>
        /// Devuelve lista de Categorias
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
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

        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }
    }
}