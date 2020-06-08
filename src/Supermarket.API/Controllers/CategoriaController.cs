using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Supermarket.API.Models;

namespace Supermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Constructor del controlador 
        /// para inicializar la inyección de dependencias ApiContext
        /// </summary>
        public CategoriaController(){}

        /// <summary>
        /// GET api/categoria
        /// Permite obtener lista de categorias desde db
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCategorias()
        {
            return new List<string> { };
        }

        /// <summary>
        /// GET api/categoria/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> GetCategoriaById(int id)
        {
            return null;
        }

        // POST api/categoria
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/categoria/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/categoria/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}