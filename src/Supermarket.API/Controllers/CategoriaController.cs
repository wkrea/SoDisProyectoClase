using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Modelos;
using System.Threading.Tasks;

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
        // /// GET api/categoria
        // [HttpGet]
        // /// Secuencial 
        //  public ActionResult<IEnumerable<Categoria>> Get()
        // {
        //     /// Retorna una lista de las categorías en la BD
        //     return context.GetCategorias().ToList();
        // }       
        /// GET api/categoria
        [HttpGet]
        /// Asincronas ->Usa paralelismo en el servidor
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            /// Retorna una objeto asincrono que se evalua en el repositorio
            return await context.GetCategoriasAsync();
        } 
        /// GET api/categoria/1  -> Asincrono
        [HttpGet("{id}")]
        /// <summary>
        /// Método que recibe un id:identificador y retorna los datos de esa categoría
        /// </summary>
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            /// Obtiene la información de la categoria llamando al metodo asincrono en el repositorio
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }
    }
}