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
        public Categoria FindCategoriaById(int id)
        {
            throw new System.NotImplementedException();
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
    }

}