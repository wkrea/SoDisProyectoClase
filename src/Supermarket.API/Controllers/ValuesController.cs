using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
    /// <summary>
    /// Ejemplo que demuestra los conceptos básicos de 
    /// HTTP y controladores
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // obtener información de manera grupal, sin necesidad de un parámetro 
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            // obtener información de manera individual recibiendo un parámetro 
            return String.Format("HttpGet del elemento {0}", id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            // permitir la creación de un elemento apoyado en los parámetros recibidos
            return String.Format("HttpPost {0}", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            // permitir la modificación de un elemento apoyado en los parámetros recibidos
            return String.Format("HttpPut modificar elmento {0}, con el valor {1}", id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            // permitir la eliminación de un elemento apoyado en los parámetros recibidos
            return String.Format("HttpDelete {0}", id);
        }
    }
}
