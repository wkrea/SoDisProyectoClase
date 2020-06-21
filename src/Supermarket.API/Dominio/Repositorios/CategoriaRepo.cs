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
        ///Creamos una categoría, el metodo debe ser asincrono debido a las validaciones necesarias del proceso
         public void crearCategoria(Categoria categoria)
        {
            db.categorias.AddAsync(categoria);
        }
        ///Editamos la categoría reteniendo las llaves primarias y tomando lo que suministramos en el Update 
        public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State= EntityState.Modified;
            db.categorias.Update(categoria);
        }
        ///El metodo recibe la categoría y la borra,  no es asincrono por que la eliminación no afecta la ejecución de la App desde aquí
        public void eliminarCategoria(Categoria categoria)
        {
            db.categorias.Remove(categoria);
        }
        ///El metodo recibe la categoría a guardar y la retorna sólo si el guardado es exitoso 
        public async Task<Categoria> guardarCategoria(Categoria categoria)
        {
            await db.SaveChangesAsync();
            return categoria;
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
        public async Task<Categoria> GetCategoriasAsyncById(int id)
        {
            /// utilizo el metodo del apiContext DbSet, le pasamos el id y él lo busca en la BD
            return await db.categorias.FindAsync(id);
        }
    }
}