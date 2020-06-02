using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.eoviedo1.Controllers
{
    [Route("eoviedo1/[controller]")]
    [eoviedo1Controller]
    public class ValuesController : ControllerBase
    {
        // GET eoviedo1/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET eoviedo1/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("Get individual parametro {0}",id);
        }

        // POST eoviedo1/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return String.Format("Post crear un registros con los datos {0}",value);
        }

        // PUT eoviedo1/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE eoviedo1/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            return String.Format("eliminar el valor {0}",id);
        }
    }
}
