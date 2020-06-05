using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
    [Route("dtorres10/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET dtorres10/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET dtorres10/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("get: Es utilizado únicamente para consultar información al servidor {0}", id);
        }

        // POST dtorres10/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            return String.Format("post: Es utilizado para solicitar la creación de un nuevo registro, es decir, algo que no existía previamente. {0}", value);
        }

        // PUT dtorres10/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            return String.Format("put: Se utiliza para actualizar por completo un registro existente. {0}, con el registro {1}", id, value);
        }

        // DELETE dtorres10/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            return String.Format("DELETE: Este método se utiliza para eliminar un registro existente.{0}", id);
        }
    }
}
