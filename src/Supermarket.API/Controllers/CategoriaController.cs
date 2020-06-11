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
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            return context.GetCategorias().ToList();
        } 
        
        // Get api/categoria
        //asincrono
        public async Task<IEnumerable<Categoria>> GetAsinc()
        {
            return await context.GetCategoriasAsync();
            
        }

        // GET api/categoria/1
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}