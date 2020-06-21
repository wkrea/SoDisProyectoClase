using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;
using System.Threading;
using System.Threading.Tasks;

namespace Supermarket.API.Dominio.Repositorio
{
  ///<summary>
    ///interfaz (API Contract)
    ///permite definir los metodos que permitiran acceder a la logica de negocio 
    ///aislando la capa de acceso 
    /// </summary>

  public interface ICategoriaRepo
  {
    /// <summary>
    /// al momento de implementar esta clase se concede la conexion a la base de datos para luego mostrar el contenido de las categorias de los productos
    ///metodo sincrono 
    /// </summary>
    /// <returns></returns>
      //IEnumerable<Categoria> GetCategorias();
      /// <summary>
      ///metodo asincrono 
    /// al momento de implementar esta clase se concede la conexion a la base de datos para luego mostrar el contenido de las categorias de los productos
    
    /// </summary>

    /// <returns></returns>
      Task<IEnumerable<Categoria>> GetCategoriasAsync();  
    /// <summary>
    /// para obtener la informacion de la categoria se debe realizar por medio del parametro id
    /// </summary>
    /// <param name="id">identificador de la categoria </param>
    /// <returns></returns>

      Task<Categoria> FindCategoriaById(int id);
    //Task<IEnumerable<Categoria>> GetCategoriaAsync();

    /// <summary>
    /// crear una categoria
    /// </summary>
    /// <param name="categoria">identificador de la categoria </param>
    void crearCategoria( Categoria categoria);

    /// <summary>
    /// editar una categoria
    /// </summary>
    /// <param name = "id"></param>
    /// <param name="categoria">identificador de la categoria </param>
    void editarCategoria(int id, Categoria categoria);

    /// <summary>
    /// eliminar una categoria
    /// </summary>
    /// <param name="categoria">identificador de la categoria </param>
    void eliminarCategoria(Categoria categoria);

    /// <summary>
    /// guardar una categoria
    /// </summary>
    /// <param name="categoria">identificador de la categoria </param>
    ///<returns></returns>
    Task<Categoria> guardarCategoria(Categoria categoria);

  }
}