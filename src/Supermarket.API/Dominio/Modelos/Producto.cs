using System.ComponentModel.DataAnnotations;
using System;
using System.Net.Http.Handlers;

namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        //[key]
        public int id { get; set; }

        //[Requere]
        public string nombre { get; set; }
        public int cantidadPaquete { get; set; }
        //public EUnidadDeMedida unidadDeMedida {get; set;}
    
        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }
    
    }
}