using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /// <summary>
        /// Permite Tener la lista de Categoria desde la Base
        /// </summary>
        /// <returns></returns>
         IEnumerable<Categoria>  GetCategorias();
         /// <summary>
         /// permite obtener la informacion de la categoria asociada al 
         /// identificador pasado como parametro
         /// </summary>
         /// <param name="id"> identificador de la categoria</param>
         /// <returns></returns>
         
          Categoria  FinCategoria( int id);
    }
}