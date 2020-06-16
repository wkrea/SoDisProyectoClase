using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Linq;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // request api/categoria (Get, Put, Delete)
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepo context;
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

        // // GET api/categoria
        // // Secuencial
        // [HttpGet]
        // public ActionResult<IEnumerable<Categoria>> Get()
        // {
        //     return context.GetCategorias().ToList();
        // }

        // GET api/categoria
        // Asíncronas --> Usa paralelismo en el servidor
        [HttpGet]
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            return await context.GetCategoriasAsync();
        }


        // GET api/categoria/1
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }
    }
}