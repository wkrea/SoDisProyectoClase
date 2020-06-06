using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Devuelve la lista de categorias desde la base de datos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Categoria> GetCategorias();
        /// <summary>
        /// Devuelve al info de la categoria asociada al identificador
        /// pasado por el parametro
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        /// <returns></returns>
        Categoria FindCategoriaById(int id);
    }
}