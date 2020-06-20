using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.Api.Dominio.Modelos;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    /// <summary>
    /// Maneja la informacion de la base
    /// </summary>
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context">Objeto</param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // Get api/categoria
        [HttpGet]
        /* public ActionResult<IEnumerable<Categoria>> Get()
        {
            return context.GetCategorias().ToList();
        } */ 
        
        // Get api/categoria
        //asincrono
        public async Task<IEnumerable<Categoria>> GetAsinc()
        {
            return await context.GetCategoriasAsync();
            
        }

        // GET api/categoria/1 
        //metodo asincrono
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
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

        // DELETE api/categoria/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria( int id)
        {
            Categoria existe = await context.FindCategoriaById(id);
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