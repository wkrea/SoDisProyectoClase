using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.Api.Dominio.Modelos;

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
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return context.GetCategorias().ToList();
        } 

        // GET api/categoria/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}