namespace Supermarket.API.Dominio.Entidades
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public short cantXpaquete { get; set; }
        public EUndMedida unidadDMedida { get; set; }

        public int categoriaId { get; set; }
        public Categoria categoria { get; set; }

    }
}