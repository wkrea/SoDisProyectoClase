using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Implementación del patron MVC para definir controladores de la interfaz de la api
    /// Aca se genera consulta a api/categorías (get, put, delete)
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Declaración de variable para tener acceso al contexto
        /// definido en la interfaz ICategoriaRepo
        /// </summary>
        private readonly ICategoriaRepo context;

        /// <summary>
        /// Constructor del controlador 
        /// para inicializar la inyección de dependencias ICategoriaRepo
        /// </summary>
        public CategoriaController(ICategoriaRepo categoriaContexto)
        {
            context = categoriaContexto;
        }

        /// <summary>
        /// GET api/values
        /// Version sincrónica
        /// Obtener categorías desde la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            /// Permite obtener la lista de categorías desde la base
            var categorias = context.GetCategorias().ToList();    // versión sincrónica
            return categorias;

        }
       
        /// <summary>
        /// GET api/values
        /// Version asíncrona
        /// Obtener categorías desde la base de datos (usa paralelismo en el servidor)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            // Permite obtener la lista de categorías desde la base
            // de forma asíncrona (no bloqueante)
            var categorias = await context.GetCategoriasAsync();    // versión asíncrona
            return categorias;
        }

        /// <summary>
        /// GET api/categoria/5
        /// Version asíncrona, 
        /// obtener información de manera identificador de categoría como parámetro 
        /// </summary>
        /// <param name="id">identificador de categoría como</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Categoria> GetCategoriaById(int id)
        {
            var categoria = await context.GetCategoriasAsyncById(id);
            return categoria;
        }

        // POST api/categoria
        [HttpPost("")]
        public async Task<IActionResult> CrearCategoria([FromBody] Categoria resource)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState);
            
            await context.CrearAsync(resource);

            await context.GuardarAsync(resource);

            return CreatedAtAction("GetCategoriaById", new { id = resource.id }, resource);
        }

        // PUT api/categoria/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletestringById(int id)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await context.GetCategoriasAsyncById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            await context.EliminarAsync(categoria);

            return Redirect("GetCategoriasAsync");
        }
    }
}