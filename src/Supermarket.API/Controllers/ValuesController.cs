using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.API.Controllers
{
    [Route("rcarrillo1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET rcarrillo1/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET rcarrillo1/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST rcarrillo1/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT rcarrillo1/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE rcarrillo1/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
