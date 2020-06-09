using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Modelos.Repositorios;
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