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
        /// obtener categorías
        /// Implementación secuencial sincrónica
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> lista = db.categorias.ToList();
            return lista;
        }

        /// <summary>
        /// obtener categorías
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
        /// obtener categoría por identificador
        /// Implementación Asincrónica
        /// </summary>
        /// <returns></returns>
        public async Task<Categoria> GetCategoriasAsyncById(int id)
        {
            var categoria = await db.categorias.FindAsync(id);
            return categoria;
        }

        /// <summary>
        /// crear categoría
        /// Implementación Asincrónica
        /// </summary>
        /// <returns></returns>
        public async Task<Categoria> CrearCategoria(int id)
        {
            var categoria = await db.categorias.FindAsync(id);
            return categoria;
        }
        
        /// <summary>
        /// modificar categoría por identificador
        /// Implementación Asincrónica
        /// </summary>
        /// <returns></returns>
        public async Task CrearAsync(Categoria categoria)
        {
            try{
                await db.categorias.AddAsync(categoria);
            }
            catch
            {
                // registrar en log
            }
        }

        public async Task ModificarAsync(int id, Categoria categoria)
        {
            // try
            // {
                var existe =  await db.categorias.FindAsync(id);

                if (!existe)
                {
                }

                db.Entry(categoria).State = EntityState.Modified;
            // }
            // catch
            // {
            //     // registrar en log
            // }
        }

        public async Task EliminarAsync(Categoria categoriaExiste)
        {
            db.Set<Categoria>().Remove(categoriaExiste);
            await db.SaveChangesAsync();
        }

        public async Task<Categoria> GuardarAsync(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
        }
    }
}