using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    //request api/categoria (Get, Put, Delete)
    public class CategoriaController: ControllerBase
    {
        private readonly ICategoriaRepo context;
         /// <summary>
        ///representa  el constructor categoria
        /// </summary>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context= CategoriaContexto;
        }

        //GET api/categoria
        /// <summary>
        ///Version Secuencial
        /*/// </summary>
         public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            return context.GetCategorias().ToList();
            //esto es refente a un cursor en base de datos
        }*/
        /// <summary>
        ///Version Asincrona-->usa paralelismo en el servidor
        /// </summary>
        public async  Task<IEnumerable<Categoria>> GetAsync()
        {
            //return new string[] { "value1", "value2" };
            
            return  await context.GetCategoriasAsync();
            //esto es refente a un cursor en base de datos
        }
        // GET api/categoria/1
        [HttpGet("{id}")]
        /// <summary>
        ///representa  un metodo que toma un valor y lo busca en la base de datos
        /// </summary>
        public ActionResult<string> FindCategoriaById(int id)
        {
            return ("values");
        }
    }
}