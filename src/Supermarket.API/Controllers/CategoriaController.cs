using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //genera consulta a api/categorias (get, put, delete)

     //Implementacion del patro MVC para definir controladores de la interfaz de la api
    public class CategoriaController : ControllerBase
    {
        //Invocacion de la interfaz
        private readonly ICategoriaRepo context;
        //Inicializacion del constructor del controlador
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;            
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
           
           ///Permite obtener la lista de categorias desde la base
            return context.GetCategorias().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {           
            return "value1";
        }
    }
}