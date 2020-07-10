using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Dominio.Servicios.Responses
{
    /// <summary>
    /// Clase que permite definir la respuesta al protocolo HTTP
    /// cuando se hace llamado a alguno de los métodos definidos en
    /// el controlador de ProductosController
    /// </summary>
    public class ProductoResponse : BaseResponse
    {
        public Producto Producto { get; private set; }

        private ProductoResponse(bool success, string mensaje, Producto producto) : base(success, mensaje)
        {
            Producto = producto;
        }

        public ProductoResponse(Producto producto) : this(true, string.Empty, producto) { }

        public ProductoResponse(string mensaje) : this(false, mensaje, null) { }
    }
}