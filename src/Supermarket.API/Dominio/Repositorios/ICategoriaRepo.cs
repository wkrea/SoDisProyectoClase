using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <sumary>
        //Permite obtener la lista de categorías desde la base
        /// </sumary>
        /// <returns> </returns>
        IEnumerable<Categoria> GetCategorias();

        /// <sumary>
        //Permite obtener la información de la categoría asociada 
        ///al identificador pasado por parámetro
        /// </sumary>
        /// <param name="id"> Identificador de la Categoría </param>
        /// <returns> </returns>
        Categoria FindCategoriaById(int id);
    }
}