using System.Collections;
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
        /// <summary>
        /// MOdelo para la definicion y descripcion de la base de datos 
        /// </summary>
        private readonly SupermarketApiContext db;

        public CategoriaRepo(SupermarketApiContext Apicontext)
        {
            db = Apicontext;
        }

        /// <summary>
        /// Implemetacion  metodo secuencial
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<Categoria> GetCategorias()
        //{
        //    IEnumerable<Categoria> lista = db.categorias.ToList();
        //    return lista;
        //}

        /// <summary>
        /// Implementacion metodo Asincrono --> usa paralelismo en el servidor
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }

        public IEnumerable<Categoria> FindCategoriasById(int id)
        {
            throw new System.NotImplementedException();
        }


    }
}