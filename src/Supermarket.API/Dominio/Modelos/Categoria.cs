using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Esta clase define la estructura de datos que representa la entidad:
    /// 
    ///     Categoria en la base de datos
    /// 
    /// Permite el acceso a la información de los productos
    /// asociados a la categoría, mediante:
    /// 
    /// La relación:
    ///     Categoria -> Producto
    /// Filtrando por:
    ///     id
    /// 
    /// </summary>
    public class Categoria
    {
        # region Atributos de Entidad Categoría
        /// <summary>
        /// Propiedad de identificador con sus metodos de acceso para las categorías
        /// </summary>
        /// <value></value>
        public int id {get; set;}
        /// <summary>
        /// Propiedad Nombre con sus metodos de acceso para las categorías
        /// </summary>
        /// <value></value>
        public string nombre {get; set;}
        #endregion

        #region Relación Categoría -> Productos
        /// <summary>
        /// Productos definidos dentro de la categoría 
        /// </summary>
        /// <value></value>   
        public IList<Producto> productos { get; set; } 
        #endregion
    }
}
