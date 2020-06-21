using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
    /// <summary>
    /// Permite definir la forma como se manejara la bd 
    /// el DbContext me sirve como emulador que me da el EntityFrameworkCore
    /// </summary>
    public class SupermarketApiContext : DbContext
    {
        /// <summary>
        /// Creacion del contructor de esta clase que deriva del DbContext
        /// </summary>
        /// <param name="options">Son las que poseen el string de conexion y permiten definirse en startups.cs </param>
        /// <returns></returns>
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {
            Database.EnsureCreated(); // Asegura que la base esta creada antes arrancar
        }

        /// <summary>
        /// Tabla que representa la categoria
        /// </summary>
        /// <value></value>
        public DbSet<Categoria> categorias {get; set;}
        /// <summary>
        /// Tabla que representa el producto
        /// </summary>
        /// <value></value>
        public DbSet<Producto> productos {get; set;}

        protected override void OnModelCreating(ModelBuilder builder){
            // Crear la base de Datos
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(c => c.id);
            builder.Entity<Categoria>()
                        .Property(c => c.nombre)
                        .IsRequired()
                        .HasMaxLength(30);

            builder.Entity<Categoria>().HasData(
                new Categoria(){id=1, nombre="Categoria 1"},
                new Categoria(){id=2, nombre="Categoria 2"},
                new Categoria(){id=3, nombre="Categoria 3"}
            );
        }
    }
}