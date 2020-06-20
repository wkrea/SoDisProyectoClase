using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        Task<IEnumerable<Categoria>> GetCatergoriaAsync();

        
    
    // este es el metodo paralelo
        Task<Categoria> GetCatergoriaAsyncById(int id);

        void crearCategoria(Categoria categoria);

        void editarCategoria(int id, Categoria categoria);
        void eliminarCategoria(Categoria categoria);

        Task<Categoria> guardarCategoria(Categoria categoria);

    }
}