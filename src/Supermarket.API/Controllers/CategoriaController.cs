using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //request api
    public class CategoriaController : ControllerBase
    {
      /// <summary>
      /// Conexion segura a la Base de Datos
      /// </summary>
      private readonly ICategoriaRepo context;

        /// <summary>
        /// categoriacontroller.cs es la que se encarga de contener los metodos que estan dentro de context para poder traer las categorias en contexto que estan en ICategoriaRepo
        
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }



        // GET jduran9/values
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };

            return context.GetCategorias().ToList();
        }

        // GET jduran9/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}