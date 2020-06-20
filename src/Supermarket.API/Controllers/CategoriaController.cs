using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/controller")]
    //request api/categoria de algun tipo manejando la logiaca
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<Categoria>> Get()
       // {
            // obtener información de manera grupal, sin necesidad de un parámetro 
            //return new string[] { "value1", "value2" };
          //  return context.GetCatergoria().ToList();
  
        // }
        //Get api/categoria
        //Asincronas --> paralelismo
         public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCatergoriaAsync();
  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Categoria> HallarFindCategoriaById(int id)
        {
            Categoria resultado = await context.GetCatergoriaAsyncById(id);
            return resultado;
        }


        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             context.crearCategoria(categoria);
             var guardadoOk = await context.guardarCategoria(categoria); //Commit
             return Ok();
        }

        //DELET api/categoria/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria(int id )
        {
            Categoria existe = await context.GetCatergoriaAsyncById(id);
            if(existe == null)
            {
                return NotFound();
            }
            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoria(existe); //CQRS, unitfwork (repositorios)

            return Ok();
        }
    }
}