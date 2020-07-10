using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Servicios.Responses;

namespace Supermarket.API.Dominio.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaServicio(ICategoriaRepositorio categoriaRepositorio, IUnitOfWork unitOfWork)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            return await _categoriaRepositorio.ListAsync();
        }

        public async Task<CategoriaResponse> SaveAsync(Categoria categoria)
        {
            try
            {
                await _categoriaRepositorio.AddAsync(categoria);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(categoria);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoriaResponse($"Se produjo un error al guardar la categoría: {ex.Message}");
            }
        }

        public async Task<CategoriaResponse> UpdateAsync(int id, Categoria categoria)
        {
            var categoriaExistente = await _categoriaRepositorio.FindByIdAsync(id);

            if (categoriaExistente == null)
                return new CategoriaResponse("Categoría no encontrada.");

            categoriaExistente.nombre = categoria.nombre;

            try
            {
                _categoriaRepositorio.Update(categoriaExistente);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(categoriaExistente);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoriaResponse($"Se produjo un error al actualizar la categoría: {ex.Message}");
            }
        }

        public async Task<CategoriaResponse> DeleteAsync(int id)
        {
            var categoriaExistente = await _categoriaRepositorio.FindByIdAsync(id);

            if (categoriaExistente == null)
                return new CategoriaResponse("Categoría no encontrada.");

            try
            {
                _categoriaRepositorio.Remove(categoriaExistente);
                await _unitOfWork.CompleteAsync();

                return new CategoriaResponse(categoriaExistente);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoriaResponse($"Se produjo un error al borrar la categoría: {ex.Message}");
            }
        }
    }
}