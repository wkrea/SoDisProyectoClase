namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        //Definicion de atributos dentro de la clase de Producto
        public int id {get; set;}
       /// <summary>
        ///representa al identificador unico del producto
        /// </summary> 
        public string nombre {get; set;}
        /// <summary>
        ///representa al nombre  del producto 
        /// </summary> 
        public int cantidadPaquete {get; set;}
        /// <summary>
        /// Cantidad de paquete
        /// </summary>   
       //public EunidadDeMedida unidadDeMedida {get; set;} 
       public int categoriaId {get; set;} 
        /// <summary>
        /// Obtención de valores Foraneos de la Clase Categoria
        /// </summary>   
       public   Categoria categoria {get; set;} 
        /// <summary>
        /// objeto categoria de la Clase Categoria
        /// </summary>
    }
}