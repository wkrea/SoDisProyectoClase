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
        /// GET nmalddonado1/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// GET nmalddonado1/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return String.Format("Get individual con el parametro {0}", id);//return "value";
        }

        /// POST nmalddonado1/values 
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return String.Format("Post: se créo un registro con los datos {0}", value);
        }

        /// PUT nmalddonado1/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return String.Format("Metodo Put {0}",value);
        }

        /// DELETE nmalddonado1/values/5
        [HttpDelete("{id}")]
        ///ActionResul permite la acción impresión en el metodo
        public ActionResult<string> Delete(int id)
        {
             return String.Format("Delete, se borró el id {0}",id);
        }
    }
}
