namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Esta clase define la estructura de datos 
    /// que representa la entidad Producto en la base de datos
    /// Permite el acceso a la información de la categoría
    /// con la que está relacionada el producto, mediante:
    /// 
    /// La relación:
    ///     Producto -> Categoria
    /// Filtrando por:
    ///     categoriasId
    /// 
    /// </summary>
    public class Producto
    {
        # region Atributos de Entidad Producto
        /// <summary>
        /// Propiedad de identificador con sus metodos de acceso para los productos
        /// </summary>
        /// <value></value>
        public int id {get; set;}
        /// <summary>
        /// Propiedad Nombre con sus metodos de acceso para los productos
        /// </summary>
        /// <value></value>
        public string nombre {get; set;}
        public int cantidasxPaquete {get; set;}      

        // public EUnidadDeMedida unidadDeMedida {get; set;}
        #endregion


        #region Relación Productos -> Categoría
        /// <summary>
        /// Llave foránea en tabla Categorías
        /// </summary>
        /// <value></value>
        public int categoriaId {get; set;}
        /// <summary>
        /// Registros obtenidos al filtrar teniendo en cuenta
        /// el valor que toma la llave foránea categoriaId
        /// </summary>
        /// <value></value>
        public Categoria categoria {get; set;}   

        #endregion
    }
}
