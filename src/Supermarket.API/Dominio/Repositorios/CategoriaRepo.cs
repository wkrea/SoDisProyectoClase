using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Persistencia;

using Supermarket.API.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Dominio.Repositorios
{
    public class CategoriaRepo : ICategoriaRepo
    {

        /// <summary>
        /// Declaración de variable para tener acceso al contexto
        /// definido en la interfaz SupermarketApiContext
        /// </summary>
        private readonly SupermarketApiContext db;
        /// <summary>
        /// Constructor del controlador 
        /// para inicializar la inyección de dependencias SupermarketApiContext
        /// </summary>
        public CategoriaRepo(SupermarketApiContext context)
        {
            db = context;
        }

        /// <summary>
        /// Implementación secuencial sincrónica
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }

        /// <summary>
        /// Implementación secuencial asíncrona (no bloqueante)
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            // https://markheath.net/post/async-antipatterns
            // https://www.campusmvp.es/recursos/post/async-y-await-en-c-como-manejar-asincronismo-en-net-de-manera-facil.aspx
            // https://docs.microsoft.com/en-us/ef/core/querying/async
            // https://www.learnentityframeworkcore.com/walkthroughs/aspnetcore-application

            List<Categoria> lista;
            lista = await db.categorias.AsNoTracking().ToListAsync();
            return lista;
        }
        /// <summary>
        /// Implementación secuencial sincrónica
        /// </summary>
        /// <returns></returns>
        public Categoria GetCategoriasAsyncById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}