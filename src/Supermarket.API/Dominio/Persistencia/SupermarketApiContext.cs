using Microsoft.EntityFrameworkCore;
using Supermarket.Api.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{

    /// <summary>
    /// Emula una base de datos
    /// </summary>
    /// <param name="Options"></param>
    /// <returns></returns>
    public class SupermarketApiContext : DbContext
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <value></value>
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> Options) : base(Options)
        {
            PoblarBase();
            Database.EnsureCreated(); 
        }
        //tablas 
        public DbSet<Categoria> categorias {get; set; }
        /// <summary>
        /// Dataset de la base de datos que representa Categoria
        /// </summary>
        /// <value></value>
        public DbSet<Producto> productos {get; set; }
        /// <summary>
        /// Dataset de la base de datos que representa Producto
        /// </summary>
        /// <value></value>
        

        //seed (DB memoria)

        /// <summary>
        /// Seed de la base de datos
        /// </summary>
        public void PoblarBase()
        {
            this.categorias.Add(
                new Categoria{
                    id = 1,
                    nombre = "Categoria 1"
                
                }
            );

            this.categorias.Add(
                new Categoria{
                    id = 2,
                    nombre = "Categoria 2"
                
                }
            );
            //Commit(guarda en la base de datos)
            this.SaveChanges();
        }


    }
}