using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Controllers
{
    [ApiController]
    // ruta por la cual se puede acceder al al api
    [Route("api/[controller]")]

    /// <summary>
    /// request api/catagorias ( Get, Put, Delete)
    /// nos permite optener datos de las clases 
    /// </summary>
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// maneja la informacion de la base 
        /// </summary>
        private readonly ICategoriaRepo context;
        
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

         // GET api/categoria
         /// <summary>
         /// permite otener respuestas tipo jason de listas de categorias 
         /// metodo secuencial
         /// </summary>
         /// <returns> listas de las categorias </returns>
        // [HttpGet]
        // public ActionResult<IEnumerable<Categoria>> Get()
        // {
        //    return context.GetCategorias().ToList();
        // }

        // GET api/categoria
         /// <summary>
         /// permite otener respuestas tipo jason de listas de categorias 
         /// metodo Asincrono --> usa paralelismo en el servidor
         /// </summary>
         /// <returns> listas de las categorias </returns>
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCategoriasAsync();
        }
        
        // GET api/categoria/1
        /// <summary>
        /// nos permiter optener informacion de una categoria especifica
        /// </summary>
        /// <param name="id"> parametro de la cataegoria</param>
        /// <returns> categoria consultada</returns>
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.GetCategoriasAsyncById(id);
            return resultado;
        }

        // POST api/categoria
        /// <summary>
        /// Permite crear las categorias y las validaciones 
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> crearCategoria([FromBody] Categoria categoria)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.crearCategoria(categoria);
            var guardadoOk = await context.guardarCategoria(categoria); // commit // P. CORS. unitofwork (P. Repositorio)
            return Ok();
        }


        // DELETE api/categoria/1
        /// <summary>
        /// permite eliminar las categorias y sus validaciones 
        /// </summary>
        /// <param name="id">id de la categoria que se quiere eliminar </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> eliminarCategoria(int id)
        {
            Categoria existe = await context.GetCategoriasAsyncById(id);
            if(existe == null)
            {
                return NotFound();
            }
            context.eliminarCategoria(existe);
            var guardadoOk = await context.guardarCategoria(existe); // commit
            return Ok();
        } 
    }
} 