using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext 
    {
        /// <summary>
        /// Definicion del Constructor que deriva del "DbContext" encargado de manipular la base
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {
            Poblarbase();
            Database.EnsureCreated();
        }
        /// <summary>
        /// Tablas props de la clase que se encarga de establecer migraciones de la Db a partir de los modelos de dominio
        /// </summary>
        /// <value></value>
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
        /// <summary>
        /// Seed de la base (semillas de informacion) -- DB en memoria
        /// </summary>
        public void Poblarbase()
        {
            /// <summary>
            /// Se crean valores para el metodo Poblarbase para ejecutar pruebas de ejecucion del proyecto
            /// </summary>
            /// <value></value>
            this.categorias.Add(
                new Categoria{
                    id = 1,
                    nombre = "Categoria 1"
                }
            );
            /// <summary>
            /// Segundo registro de valores para Poblarbase para pruebas de ejecucion
            /// </summary>
            /// <value></value>
            this.categorias.Add(
                new Categoria{
                    id = 2,
                    nombre = "Categoria 2"
                }
            ); 
        }
    }
}