namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidadxPaquete { get; set; }
        // public EUnidadDeMedida unidadDeMedida {get; set;}

        public int categoriaId { get; set; }
        public Categoria categoria  { get; set; }
    }
}
