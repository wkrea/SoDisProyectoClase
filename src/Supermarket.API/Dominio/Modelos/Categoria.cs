

using System.Collections.Generic;

namespace Supermarket.API.Dominio.Modelos
{
    
    public class Categoria
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        ///Relacion entre categoria y productos    
        public IList<Producto> productos {get; set;}  
    }


}