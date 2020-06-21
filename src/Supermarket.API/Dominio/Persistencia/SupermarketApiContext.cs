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
        public DbSet<Producto> productos {get;  set;}
        
        /// <summary>
        /// Metodo indicado para definir la estructura de la BD
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(categoria => categoria.id);
            builder.Entity<Categoria>().Property(categoria => categoria.id).ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(categoria => categoria.nombre).HasColumnName("NombreCompleto");
            builder.Entity<Categoria>()
                    .Property(categorias => categorias.nombre)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Entity<Categoria>().HasData(
              new Categoria(){ id =1, nombre = "Categoria 1" },
              new Categoria(){ id =2, nombre = "Categoria 2" },
              new Categoria(){ id =3, nombre = "Categoria 3" }
            );
        }
        //Seed de la base(semillas de informacion) -- BD en memoria
        //public void PoblarBase()
        //{
          //  this.categorias.Add(
            //    new Categoria{
              //      id = 1,
                //    nombre = "Categoria 1",
                //}
            //);

            //this.categorias.Add(
            //new Categoria{
              //      id = 2,
                //    nombre = "Categoria 2",
                //}
            //);
            //commit
            //this.SaveChanges();
        //}
    }
}