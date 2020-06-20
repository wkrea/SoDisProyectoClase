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
          Task<Categoria>  FindCategoriaById( int id);
         /// <summary>
         /// Permite crear una nueva categoria  
         ///  un objeto un categoria de la clase Categoria pasado como parametro
         /// </summary>
         /// <param name="categoria"> Objeto de la clase Categoria</param>
         /// <returns></returns>
          void crearCategoria(Categoria categoria);
         /// <summary>
         /// Permite modificar  una  categoria ya creada pasandole el id y un objeto con las modificaciones  
         /// identificador de la categoria y un objeto categoria de la clase Categoria pasado como parametro
         /// </summary> 
         /// <param name="id"></param>
        /// <param name="categoria">id de la categoria</param>
          void editarCategoria(int id, Categoria categoria);
         /// <summary>
         /// Permite eliminar  una  categoria ya creada
         ///objeto categoria de la clase Categoria pasado como parametro
         /// </summary> 
          void eliminarCategoria(Categoria categoria);
         /// <summary>
         /// se refiere a guardar una categoria
         ///objeto categoria de la clase Categoria pasado como parametro
         /// </summary> 
         /// <param name="categoria"></param>
        /// <returns></returns>
          Task<Categoria> guardarCategoria(Categoria categoria);
    }
}