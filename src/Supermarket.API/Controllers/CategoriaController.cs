using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Linq;

namespace Supermarket.API.Controllers
{
    /*Controlador de aplicaciones que posee una ruta para 
    poder versionar los servicios que agregan funcionalidades 
    a traves de url diferentes*/

    [ApiController]
    [Route("api/[controller]")]
    //requuest api/categorias (Get, Put, Delete)

    /// <summary>
    /// El controlador permite obtener los datos de cualquiera de las dos clases Categoria o Producto
    /// </summary>
    public class categoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public categoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            return await context.GetCategorias();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Categoria> FindCategoriaById(int id)
        {
            return await context.HallarCategoriaById(id);
        }

        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.crearCategoria(categoria);
            var guardadoOk = await context.guardarCategoriaById(categoria);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria(int id)
        {
            Categoria existe = await context.HallarCategoriaById(id);

            if(existe == null)
            {
                return NotFound();
            }

            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoriaById(existe);
            return Ok();
        }
    }
}