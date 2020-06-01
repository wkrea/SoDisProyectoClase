using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
    [Route("nmaldonado1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("Get individual con el parametro {0}", id);//return "value";
        }

        // POST api/values 
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return String.Format("Post: se créo un registro con los datos {0}", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return String.Format("Metodo Put {0}",value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)//ActionResul permite la acción impresión en el metodo
        {
             return String.Format("Delete, se borró el id {0}",id);
        }
    }
}
