using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorio;
using Supermarket.API.Dominio.Persistencia;
using System.Threading;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
  /*Controlador de aplicaciones que posee una ruta para poder versionar los servicios que agregan funcionalidades a traves de url diferentes*/
  [Route("api/[controller]")]
  [ApiController]
  //request api/categoria
  /// <summary>
  /// Este controlador me permite obtener los datos de cualquiera de las dos clases Categoria.cs o Producto.cs
  /// </summary>
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
    // GET api/categoria
        //[HttpGet]
        //public ActionResult<IEnumerable<Categoria>> Get()
        //{
            //return new string[] { "value1", "value2" };

          //  return context.GetCategorias().ToList();
        //}
         // GET api/categoria
         //version asincrona --> usoo paralelismo en el servidor 

        [HttpGet]
        /// <summary>
        /// es el inicio entre la solicitud del cliente y el retorno de la informacion que el mismo pide con respuestas de tipo json
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCategoriasAsync();
        }
        // GET api/categoria/5
        //metodo asincrono 
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }
        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria )
        {
          if (!ModelState.IsValid)
          {
            return BadRequest(ModelState);
          }
          context.crearCategoria(categoria);
          var guardadoOk = await context.guardarCategoria(categoria);
          return Ok();
        }

        //Delete api/categoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria (int id)
        {
          Categoria existe = await context.FindCategoriaById(id);
          if(existe ==null)
          {
            return NotFound();
          }
          context.eliminarCategoria(existe);
          var guardadoOk =await context.guardarCategoria(existe);
          return Ok();
        }
  }
}