using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// Aca se genera consulta a api/categorias (get, put, delete)
    /// </summary>///
    /// <summary>
    /// Implementacion del patron MVC para definir controladores de la interfaz de la api
    /// </summary>
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Invocacion de la interfaz///
        /// </summary>
        private readonly ICategoriaRepo context;
        /// <summary>
        /// Inicializacion del constructor del controlador
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;            
        }
        // GET api/values
        /// <summary>
        /// Version secuencial
        /// </summary>
        /// <returns></returns>
        // [HttpGet]
        // public ActionResult<IEnumerable<Categoria>> Get()
        // {
        // /// <summary>
        // /// Permite obtener la lista de categorias desde la base
        // /// </summary>
        // /// <returns></returns>         
        // return context.GetCategorias().ToList();
        // }
        // GET api/values
        /// <summary>
        /// Version asincrona, la cual usa paralelismo en el servidor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            /// <summary>
            /// Permite obtener la lista de categorias desde la base
            /// </summary>
            /// <returns></returns>         
            return await context.GetCategoriasAsync();
        }
        // GET api/categoria/1
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            /// <summary>
            /// Permite obtener la lista de categorias desde la base///
            /// </summary>           
            Categoria resultado = await context.GetCategoriasAsyncById(id);
            return resultado;
        }
        [HttpPost]
        /// <summary>
        /// Se hace verificacion del body, ve el mensaje http, lo castea como tipo categoria
        /// y cae al metodo para ser guardada
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid)
            {
                /// <summary>
                /// verifica si la informacion suministrada esta completa si no retorna mensaje de error
                /// </summary>
                /// <returns></returns>
                return BadRequest(ModelState);
            }
            context.crearCategoria(categoria);
            var guardadoOk = await context.guardarCategoria(categoria);
            return Ok();
        }
        //DELETE api/categoria/1
        [HttpDelete("{id}")]
        /// <summary>
        /// Se hace verificacion del body, ve el mensaje http, lo castea como tipo categoria
        /// y cae al metodo para ser guardada/ Este metodo permitira hacer la eliminacion de categorias
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task<ActionResult> eliminarCategoria(int id)
        {
            Categoria existe = await context.GetCategoriasAsyncById(id);
            if(existe == null)
            {
                return NotFound();
            }
            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoria(existe);
            return Ok();
        }
    }
}