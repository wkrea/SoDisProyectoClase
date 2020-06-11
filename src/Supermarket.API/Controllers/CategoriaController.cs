using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    //request api/categoria (Get, Put, Delete)
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }


        // GET rcarrillo1/values
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
           // return new string[] { "value1", "value2" };
           return context.GetCategorias().ToList();
        }

        // GET rcarrillo1/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}