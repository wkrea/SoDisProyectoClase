using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
    [Route("cortega3/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET cortega3/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET cortega3/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {           
            return String.Format("Get individual con el parametro {0}", id);
        }
        // POST cortega3/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return String.Format("Post: se creo un registro con los datos {0}", value); 
        }
        // PUT cortega3/values/5
        [HttpPut("{id}")]
        public String Put(int id, [FromBody] string value)
        {
            return String.Format("Put individual con el parametro {0}", id); 
        }
        // DELETE cortega3/values/5
        [HttpDelete("{id}")]
        public String Delete(int id)
        {
            return String.Format("Delete individual con el parametro {0}", id); 
        }
    }
}