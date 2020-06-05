namespace Supermarket.API.Dominio.Modelos
{
    
    public class Producto
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int cantidasxPaquete {get; set;}
        //public EUnidadDeMedida unidadDeMedida {get; set;}
              
        //Relacion que permite establecer conexion entre las dos entidades//
        public int categoriaId {get; set;}
        public Categoria categoria {get; set;}
        
    }


}