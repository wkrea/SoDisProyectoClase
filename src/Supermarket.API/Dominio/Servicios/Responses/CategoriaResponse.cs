using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Dominio.Servicios.Responses
{
    /// <summary>
    /// Clase que:
    /// - Implementa el patrón de fábrica para construir la respuesta HTTP
    /// - Responde al llamado de alguno de los métodos definidos en
    /// el controlador de ProductosController
    /// </summary>
    public class CategoriaResponse : BaseResponse
    {
        public Categoria Categoria { get; private set; }

        private CategoriaResponse(bool success, string mensaje, Categoria categoria) : base(success, mensaje)
        {
            Categoria = categoria;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="categoria">Saved categoria.</param>
        /// <returns>Response.</returns>
        public CategoriaResponse(Categoria categoria) : this(true, string.Empty, categoria)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="mensaje">Error mensaje.</param>
        /// <returns>Response.</returns>
        public CategoriaResponse(string mensaje) : this(false, mensaje, null)
        { }
    }
}