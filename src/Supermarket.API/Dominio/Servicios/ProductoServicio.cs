using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Servicios.Responses;

namespace Supermarket.API.Dominio.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ProductoServicio(IProductoRepositorio productoRepositorio, ICategoriaRepositorio categoriaRepositorio, IUnitOfWork unitOfWork)
        {
            _productoRepositorio = productoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Producto>> ListAsync()
        {
            return await _productoRepositorio.ListAsync();
        }

        public async Task<ProductoResponse> SaveAsync(Producto producto)
        {
            try
            {
                /*
                Aquí hay que comprobar si la identificación de la categoría es válida antes de añadir el producto, para evitar errores.
                 Puede crear un método en la clase CategoryService para devolver la categoría e inyectar el servicio aquí si lo prefiere, pero 
                 no importa dado el alcance del API.
                */
                var existingCategory = await _categoriaRepositorio.FindByIdAsync(producto.categoriaId);
                if (existingCategory == null)
                    return new ProductoResponse("Categoría inválida.");

                await _productoRepositorio.AddAsync(producto);
                await _unitOfWork.CompleteAsync();

                return new ProductoResponse(producto);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductoResponse($"Se produjo un error al guardar el producto: {ex.Message}");
            }
        }

        public async Task<ProductoResponse> UpdateAsync(int id, Producto producto)
        {
            var productoExistente = await _productoRepositorio.FindByIdAsync(id);

            if (productoExistente == null)
                return new ProductoResponse("Producto no encontrado.");

            var existingCategory = await _categoriaRepositorio.FindByIdAsync(producto.categoriaId);
            if (existingCategory == null)
                return new ProductoResponse("Categoría no válida.");

            productoExistente.nombre = producto.nombre;
            productoExistente.unidadDMedida = producto.unidadDMedida;
            productoExistente.cantXpaquete = producto.cantXpaquete;
            productoExistente.categoriaId = producto.categoriaId;

            try
            {
                _productoRepositorio.Update(productoExistente);
                await _unitOfWork.CompleteAsync();

                return new ProductoResponse(productoExistente);
            }
            catch (Exception ex)
            {
                // Haz algunas cosas de registro en log de la aplicación
                return new ProductoResponse($"Se produjo un error al actualizar el producto: {ex.Message}");
            }
        }

        public async Task<ProductoResponse> DeleteAsync(int id)
        {
            var productoExistente = await _productoRepositorio.FindByIdAsync(id);

            if (productoExistente == null)
                return new ProductoResponse("Producto no encontrado.");

            try
            {
                _productoRepositorio.Remove(productoExistente);
                await _unitOfWork.CompleteAsync();

                return new ProductoResponse(productoExistente);
            }
            catch (Exception ex)
            {
                // Haz algunas cosas de registro en log de la aplicación
                return new ProductoResponse($"Se produjo un error al borrar el producto: {ex.Message}");
            }
        }
    }
}