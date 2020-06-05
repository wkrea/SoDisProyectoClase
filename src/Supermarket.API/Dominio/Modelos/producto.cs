namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Defino la clase Productos y sus propiedades
    /// id: identificiador del producto
    /// nombre: nombre del producto
    /// CantidadxPaquete: cantidad del producto por paquete
    /// CategoriaId: Identificador de la categoría a la que pertenece
    /// </summary>
    public class Producto
    {
        public int id {get; set;}
        public string nombre {get; set;}
        public int cantidadxPaquete{get; set;}

        public int categoriaId{get; set;}
        public Categoria categoria{get; set;}
    }
}