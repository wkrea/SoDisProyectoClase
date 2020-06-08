namespace Supermarket.API.Dominio.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public short CantidadxPaquete { get; set; }
        //public EUnidadDeMedida UnidadDeMedida { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
