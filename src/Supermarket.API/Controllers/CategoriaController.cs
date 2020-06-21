using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorio;
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
    // GET jduran9/categoria
        //[HttpGet]
        //public ActionResult<IEnumerable<Categoria>> Get()
        //{
            //return new string[] { "value1", "value2" };

          //  return context.GetCategorias().ToList();
        //}
         // GET jduran9/categoria
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
        // GET jduran9/categoria/5
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }
  }
}