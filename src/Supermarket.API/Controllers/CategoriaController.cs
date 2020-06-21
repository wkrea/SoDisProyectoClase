using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Modelos;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Creamos un crontrolador para las categorías con sus request
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        /// Creo el contructor como una instancia de la inteface del repositorio 
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }
        // /// GET api/categoria
        // [HttpGet]
        // /// Secuencial 
        //  public ActionResult<IEnumerable<Categoria>> Get()
        // {
        //     /// Retorna una lista de las categorías en la BD
        //     return context.GetCategorias().ToList();
        // }       
        /// GET api/categoria
        [HttpGet]
        /// Asincronas ->Usa paralelismo en el servidor
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            /// Retorna una objeto asincrono que se evalua en el repositorio
            return await context.GetCategoriasAsync();
        } 
        /// GET api/categoria/1  -> Asincrono
        [HttpGet("{id}")]
        /// <summary>
        /// Método que recibe un id:identificador y retorna los datos de esa categoría
        /// </summary>
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            /// Obtiene la información de la categoria llamando al metodo asincrono en el repositorio
            Categoria resultado = await context.GetCategoriasAsyncById(id);
            return resultado;
        }
        /// Crear categoría
        /// En el cuerpo del mensaje en postman  se envían el id y el nombre de la categoría en formato JSON
        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            /// El ModelState verifica si la información ingresada es correcta y completa, lo usamos en un if para validar los datos
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.crearCategoria(categoria);
            var guardadoOk = await context.guardarCategoria(categoria); // commit
            return Ok();
        }
        /// Borrar categoría
        /// DELETE api/categoria/1 
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria(int id)
        {
            /// Validamos si la categoría con el id indicado existe, si no existe retornamos un 404NotFound.
            Categoria existe = await context.GetCategoriasAsyncById(id);
            if(existe==null)
            {
                return NotFound();
            }
            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoria(existe); // commit // P. CQRS, UnitOfWork (P. Repositorio)
            return Ok();
        }
    }
}