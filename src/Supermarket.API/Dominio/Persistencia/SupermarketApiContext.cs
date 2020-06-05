using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext 
    {
        //Definicion del Constructor que deriva del "DbContext" encargado de manipular la base
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {
            
        }

        //Tablas props de la clase
        //Clase que se encarga de establecer migraciones de la Db a partir de los modelos de dominio
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }


        //Seed de la base (semillas de informacion) -- DB en memoria
    }
}