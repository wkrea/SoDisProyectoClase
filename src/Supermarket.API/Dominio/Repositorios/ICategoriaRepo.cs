using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <Summary>
        /// Permite obtener la lista de categorias desde la base
        /// </Summary>
        /// <returns></returns>

        IEnumerable<Categoria> GetCategorias();

        /// <Summary>
        /// Permite obtener la informacion de la categoria asociada al identificador pasado por parametro
        /// </Summary>
        /// <param name= "id">identificador de la categoria</param>
        /// <returns></returns>


        Categoria FindCategoriaById(int id);
    }
}



