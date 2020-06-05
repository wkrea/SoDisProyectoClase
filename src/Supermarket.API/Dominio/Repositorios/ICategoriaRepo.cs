using System.Collections.Generic;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Repositorios
{
    public interface ICategoriaRepo
    {
        ///PErmite obtener la lista de categorias desde la base
        IEnumerable<Categoria> GetCategorias();
        
        ///Permite obtener la informacion de la categoria asociada al identificador pasado por parametro
        Categoria FindCategoriaById(int id);

    }
}