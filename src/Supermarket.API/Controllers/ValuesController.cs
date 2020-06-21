using System;
//using System.linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("jduran9/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET jduran9/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            // obtener información de manera grupal, sin necesidad de un parámetro 
            return new string[] { "value1", "value2" };
        }
        // GET jduran9/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("get: Es utilizado únicamente para consultar información al servidor, muy parecidos a realizar un SELECT a la base de datos. {0}", id);
        }
        // GET jduran9/values/5
        [HttpPost]
        public string Post([FromBody] string value)
        {
           return String.Format("post: Es utilizado para solicitar la creación de un nuevo registro, es decir, algo que no existía previamente, es decir, es equivalente a realizar un INSERT en la base de datos. {0}", value);
        }
        // GET jduran9/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return String.Format($"put: Se utiliza para actualizar por completo un registro existente, es decir, es parecido a realizar un UPDATE a la base de datos. {id}  algo enviado en el json {value}"); 
        }
        // GET jduran9/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return String.Format("DELETE: Este método se utiliza para eliminar un registro existente, es similar a DELETE a la base de datos {0}", id);
        }
    }
}
