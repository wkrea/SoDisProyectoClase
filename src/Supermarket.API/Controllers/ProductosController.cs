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
    public class ProductosController : Controller
    {
        private readonly IProductoServicio _productoServicio;
        private readonly IMapper _mapper;

        public ProductosController(IProductoServicio productoServicio, IMapper mapper)
        {
            _productoServicio = productoServicio;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductoRecurso>> ListAsync()
        {
            var productos = await _productoServicio.ListAsync();
            var Recursos = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoRecurso>>(productos);
            return Recursos;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductoRecurso Recurso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var producto = _mapper.Map<SaveProductoRecurso, Producto>(Recurso);
            var result = await _productoServicio.SaveAsync(producto);

            if (!result.Success)
                return BadRequest(result.Message);

            var productoRecurso = _mapper.Map<Producto, ProductoRecurso>(result.Producto);
            return Ok(productoRecurso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductoRecurso Recurso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var producto = _mapper.Map<SaveProductoRecurso, Producto>(Recurso);
            var result = await _productoServicio.UpdateAsync(id, producto);

            if (!result.Success)
                return BadRequest(result.Message);

            var productoRecurso = _mapper.Map<Producto, ProductoRecurso>(result.Producto);
            return Ok(productoRecurso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productoServicio.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryRecurso = _mapper.Map<Producto, ProductoRecurso>(result.Producto);
            return Ok(categoryRecurso);
        }
    }
}