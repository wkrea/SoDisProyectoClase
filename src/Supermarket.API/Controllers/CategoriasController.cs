using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Recursos;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Servicios;
using Supermarket.API.Extensions;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaServicio _categoriaServicio;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaServicio categoriaServicio, IMapper mapper)
        {
            _categoriaServicio = categoriaServicio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaRecurso>> ListAsync()
        {
            var categories = await _categoriaServicio.ListAsync();
            var resources = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaRecurso>>(categories);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoriaRecurso resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var categoria = _mapper.Map<SaveCategoriaRecurso, Categoria>(resource);
            var result = await _categoriaServicio.SaveAsync(categoria);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoriaResource = _mapper.Map<Categoria, CategoriaRecurso>(result.Categoria);
            return Ok(categoriaResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoriaRecurso resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var categoria = _mapper.Map<SaveCategoriaRecurso, Categoria>(resource);
            var result = await _categoriaServicio.UpdateAsync(id, categoria);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoriaResource = _mapper.Map<Categoria, CategoriaRecurso>(result.Categoria);
            return Ok(categoriaResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoriaServicio.DeleteAsync(id);

             if (!result.Success)
                return BadRequest(result.Message);

            var categoriaResource = _mapper.Map<Categoria, CategoriaRecurso>(result.Categoria);
            return Ok(categoriaResource);
        }
    }
}