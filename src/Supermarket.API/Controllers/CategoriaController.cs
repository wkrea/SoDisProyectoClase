using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Variable privada de la clase/solo lectura
        /// </summary>
        private readonly ICategoriaRepo context;
        /// <summary>
        /// Metodo contructor de la clase
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContext)
        {
            context = CategoriaContext;
        }
        //Asincrona --> Usa paralelismo en el servidor
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            
            /// <summary>
            /// Retorna lista de categoria
            /// </summary>
            /// <returns></returns>
            return await context.GetCategoriasAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.GetCategoriasAsyncById(id);
            return resultado;
        }

        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.crearCategoria(categoria);
            var guardadoOk = await context.guardarCategoria(categoria);
            return Ok();
        }

        //DELETE api/categoria/1
        [HttpDelete("{id}")]
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