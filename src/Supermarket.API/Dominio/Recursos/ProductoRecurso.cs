namespace Supermarket.API.Dominio.Recursos
{
    /// <summary>
    /// Clase que permite definir la estructura de datos 
    /// para entidad Producto, cuando se retorne una 
    /// respuesta a traves del protocolo HTTP
    /// 
    /// Esto permite optimizar la cantidad de información 
    /// o el ancho de banda consumido por la aplicación
    /// </summary>
    public class ProductoRecurso
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantXpaquete { get; set; }
        public string unidadDMedida { get; set; }
        public CategoriaRecurso categoria {get;set;}
    }
}