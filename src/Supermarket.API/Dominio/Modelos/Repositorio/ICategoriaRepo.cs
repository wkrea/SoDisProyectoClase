using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorio
{
  public interface ICategoriaRepo
  {
    /// <summary>
    /// al momento de implementar esta clase se concede la conexion a la base de datos para luego mostrar el contenido de las categorias de los productos
    
    /// </summary>
    /// <returns></returns>
      IEnumerable<Categoria> GetCategorias();
    /// <summary>
    /// para obtener la informacion de la categoria se debe realizar por medio del parametro id
    /// </summary>
    /// <param name="id">identificador</param>
    /// <returns></returns>
      Categoria FindCategoriaById(int id);
  }
}