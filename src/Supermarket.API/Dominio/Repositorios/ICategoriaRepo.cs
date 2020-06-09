using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos.Repositorios
{
    /// <sumary>
    ///Permire definir los métodos que permitirán acceder la lógica de negocio
    ///aislando la capa de acceso a datos de los demás módulos con consuman los datos.
    /// </sumary>

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
        /// <param name="id"> Identificador de la categoría </param>
        /// <returns> </returns>

        Categoria FindCategoriaById(int id);
    }
}