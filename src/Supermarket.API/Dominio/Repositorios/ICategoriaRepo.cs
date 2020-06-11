using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        /* <summary>
        /// metodo sincrono
        /// Permite Tener la lista de Categoria desde la Base
        /// </summary>
        /// <returns></returns>
         IEnumerable<Categoria>  GetCategorias();*/

         

                 /// <summary>
        /// metodo sincrono
        /// Permite Tener la lista de Categoria desde la Base
        /// </summary>
        /// <returns></returns>
         Task<IEnumerable<Categoria>>  GetCategoriasAsync();

         /// <summary>
         /// permite obtener la informacion de la categoria asociada al 
         /// identificador pasado como parametro
         /// </summary>
         /// <param name="id"> identificador de la categoria</param>
         /// <returns></returns>
          Categoria  FindCategoria( int id);
    }
}