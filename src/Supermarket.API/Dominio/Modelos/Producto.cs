using System;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    /// <summary>
    /// Se crera clase que va a contener el id, nombre del producto
    /// que se listarán dentro de categoría
    /// </summary>
    public class Producto
    {
        [Key]
        /// <summary>
        /// Contiene el id del producto
        /// </summary>
        /// <value></value>
        public int id { get; set;}

        [Required]
        /// <summary>
        /// Contiene el nombre del producto
        /// </summary>
        /// <value></value>
        public string nombre {get; set;}
        /// <summary>
        /// Contiene la cantidad de producto
        /// </summary>
        /// <value></value>
        public int cantidadxPaquete {get; set;}
        //public EUnidadDeMedida unidadDeMedida {get; set;}
        /// <summary>
        /// Contiene el Id de la categoria a la que pertenece el producto
        /// </summary>
        /// <value></value>
        public int categoriaId {get; set;}
        /// <summary>
        /// Contiene la Categoria del producto
        /// </summary>
        /// <value></value>
        public Categoria categoria {get; set;}
    }
}