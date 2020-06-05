using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Creamos un crontrolador para las categorías con sus request
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        /// Creo el contructor como una instancia de la inteface del repositorio 
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

         public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            return context.GetCategorias().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            // obtener información de manera individual recibiendo un parámetro 
            return "Values";
        }

    }
}