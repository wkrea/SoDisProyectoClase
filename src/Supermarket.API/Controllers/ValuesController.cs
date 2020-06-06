using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            return new string[] { "value1", "value2" };
        }

        // GET jduran9/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("get: Es utilizado únicamente para consultar información al servidor, muy parecidos a realizar un SELECT a la base de datos. {0}", id);
        }

        // POST jduran9/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
          return String.Format("post: Es utilizado para solicitar la creación de un nuevo registro, es decir, algo que no existía previamente, es decir, es equivalente a realizar un INSERT en la base de datos. {0}", value);
        }

        // PUT jduran9/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return String.Format($"put: Se utiliza para actualizar por completo un registro existente, es decir, es parecido a realizar un UPDATE a la base de datos. {id}  algo enviado en el json {value}"); 
        }

        // DELETE jduran9/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
          return String.Format("DELETE: Este método se utiliza para eliminar un registro existente, es similar a DELETE a la base de datos {0}", id);

        }
    }
}
