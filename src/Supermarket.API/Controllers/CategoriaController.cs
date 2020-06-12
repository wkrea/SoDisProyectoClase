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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        
        /// <summary>
        /// Controla la informacion de la base
        /// </summary>
        /// <param name="context">Context</param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // Get api/categoria
        /* [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return context.GetCategorias().ToList();
        }  */

        // Get api/categoria
        //asincrono
        public async Task<IEnumerable<Categoria>> GetAsinc()
        {
            return await context.GetCategoriasAsync();
            
        }

        // GET api/categoria/1
        
        /// <summary>
        ///Metodo asincrono 
        /// </summary>
        /// <param name="id">Identificador categoria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }
    }
}