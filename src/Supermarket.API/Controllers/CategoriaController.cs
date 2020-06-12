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
    // GET api/values
        [HttpGet]
        /// <summary>
        /// Permite manejar respuestas de tipo JSON a traves de ActionResult es el punto de entrada entre las solicitudes del cliente  y retornaran la informacion que pida el cliente
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCategoriaAsync();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "value";
        }
  }
}