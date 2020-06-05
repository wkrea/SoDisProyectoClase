namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        //Definicion de atributos dentro de la clase de Producto
        public int id {get; set;}
        public string nombre {get; set;} 
        
        public int cantidadPaquete {get; set;}  
       // public EunidadDeMedida unidadDeMedida {get; set;}

       //Obtención de valores Foraneos de la Clase Categoria
       public int categoriaId {get; set;} 
       public   Categoria categoria {get; set;} 
    }
}