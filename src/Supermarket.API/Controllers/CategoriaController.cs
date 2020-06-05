using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Modelos.Repositorios;
using System.Linq;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //requuest api/categorias (Get, Put, Delete)
    public class categoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public categoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            return context.GetCategorias().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}