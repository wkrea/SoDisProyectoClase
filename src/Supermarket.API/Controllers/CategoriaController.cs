using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Linq;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // request api/categoria (Get, Put, Delete)
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // // GET api/categoria
        // // Secuencial
        // [HttpGet]
        // public ActionResult<IEnumerable<Categoria>> Get()
        // {
        //     return context.GetCategorias().ToList();
        // }

        // GET api/categoria
        // Asíncronas --> Usa paralelismo en el servidor
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCategoriasAsync();
        }


        // GET api/categoria/1
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
            var guardadoOk = await context.guardarCategoria(categoria); // commit
            return Ok();
        }

        // DELETE api/categoria/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria(int id)
        {
            Categoria existe = await context.GetCategoriasAsyncById(id);
            if(existe == null)
            {
                return NotFound();
            }

            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoria(existe); // commit // P. CQRS, UnitofWork (P. Repositorio)
            return Ok();
        }


    }
}