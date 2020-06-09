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
      /// Conexion privada de la DB
      /// </summary>
      private readonly ICategoriaRepo context;

        /// <summary>
        /// Permite contener los metodos en el objeto context para su invocacion espero lo entienda david del futuro jajajaja enserio solo es un metodo que me permite llamar lo que esta en ICategoriaRepo fijese bien confio en usted :D
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }



        // GET dtorres10/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAsync()
        {
            //return new string[] { "value1", "value2" };

            return await context.GetCategorias().ToListAsync();
        }


        // GET dtorres10/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
    }
}