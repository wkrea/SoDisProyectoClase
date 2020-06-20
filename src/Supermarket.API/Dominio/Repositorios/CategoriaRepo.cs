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
        /// implenetacion de metodo que nos permite crear nuevas categorias
        /// </summary>
        /// <param name="categoria">entidad con los datos nuevos</param>
        public void crearCategoria(Categoria categoria)
        {
            db.categorias.AddAsync(categoria);
        }

        /// <summary>
        /// implementacion de metodo secuencial para editar categorias existentesen la db
        /// </summary>
        /// <param name="id">id del elemento que se desea modoficar</param>
        /// <param name="categoria">entidad que tendra los nuevos registros</param>
        public void editarCategoria(int id, Categoria categoria)
        {
           db.Entry(categoria).State = EntityState.Modified;
           db.categorias.Update(categoria);
        }

        /// <summary>
        /// Implemetacion  metodo secuencial para eliminar categoria
        /// </summary>
        /// <param name="categoria">Entidad que queremos eliminar de la base</param>
        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }

        /// <summary>
        /// metodo que nos permite guardar datos en la base de datos
        /// Implementacion metodo Asincrono --> usa paralelismo en el servidor
        /// se retorna la categoria cuando este seguro del guardado asincrono sea exitoso
        /// </summary>
        /// <param name="categoria">Entidad que queremos guardar en la base</param>
        /// <returns></returns>
        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync(); // commit
            return categoria;
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
        /// metodo que permite obtener la lista de categorias
        /// Implementacion metodo Asincrono --> usa paralelismo en el servidor
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            IEnumerable<Categoria> lista = await db.categorias.ToListAsync();
            return lista;
        }

        /// <summary>
        /// metodo que nos permite tener una lista especifica
        /// </summary>
        /// <param name="id">id del elemento que se desea consultar</param>
        /// <returns></returns>
        public async Task<Categoria> GetCategoriasAsyncById(int id)
        {
            Categoria resultado = await db.categorias.FindAsync(id);
            return resultado;
        }
    }
}