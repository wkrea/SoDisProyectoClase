using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;

namespace Supermarket.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    //request api/categoria (Get, Put, Delete)
    public class CategoriaController: ControllerBase
    {
        private readonly ICategoriaRepo context;
        //objeto para ser utilizado en el constructor
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context= CategoriaContexto;
        }
        //GET api/values
         public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            
            return context.GetCategorias().ToList();
            //esto es refente a un cursor en base de datos
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> FindById(int id)
        {
            return ("values");
        }

        
    }
}