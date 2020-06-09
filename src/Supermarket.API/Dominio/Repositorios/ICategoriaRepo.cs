using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorio
{
  public interface ICategoriaRepo
  {
    /// <summary>
    /// La implementacion de esta clase permite la conexion con la base de datos para poder mostrar el listado de las categorias
    /// </summary>
    /// <returns></returns>
      IEnumerable<Categoria> GetCategorias();
    /// <summary>
    /// Obtiene la informacion de la categorida por medio del parametro id
    /// </summary>
    /// <param name="id">identificador</param>
    /// <returns></returns>
      Categoria FindCategoriaById(int id);
  }
}