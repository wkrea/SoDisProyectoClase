using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;
using System.Linq;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /// <summary>
    /// Aca se genera consulta a api/categorias (get, put, delete)
    /// </summary>///
    /// <summary>
    /// Implementacion del patron MVC para definir controladores de la interfaz de la api
    /// </summary>
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Invocacion de la interfaz///
        /// </summary>
        private readonly ICategoriaRepo context;
        /// <summary>
        /// Inicializacion del constructor del controlador
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;            
        }
        // GET api/values
        /// <summary>
        /// Version secuencial
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            /// <summary>
            /// Permite obtener la lista de categorias desde la base
            /// </summary>
            /// <returns></returns>         
            return context.GetCategorias().ToList();
        }
        // GET api/values
        /// <summary>
        /// Version asincrona, la cual usa paralelismo en el servidor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsyn()
        {
            /// <summary>
            /// Permite obtener la lista de categorias desde la base
            /// </summary>
            /// <returns></returns>         
            return await context.GetCategoriasAsync();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            /// <summary>
            /// Permite obtener la lista de categorias desde la base///
            /// </summary>           
            return "value1";
        }
    }
}