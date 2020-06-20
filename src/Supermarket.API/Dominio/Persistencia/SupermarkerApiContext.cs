using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext: DbContext
    {
         //Contructor
           public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
           {
             //PoblarBase();
             Database.EnsureCreated();
           }
               //Tablas "props de la clase"
               public DbSet<Categoria> categorias {get; set;}
            /// <summary>
            ///Representa un objeto de la tabla categoria
            /// </summary>     
               public DbSet<Producto> productos {get; set;}
            /// <summary>
            ///Representa un objeto de la tabla categoria
            /// agregacion de seeds
            /// </summary> 
                  protected  override void OnModelCreating( ModelBuilder builder){
                     //Fluent API
            /// <summary>
            ///Contruccion de base de datos. creacion de la tabla Categorias
            /// </summary> 
               builder.Entity<Categoria>().ToTable("Categorias");
               builder.Entity<Categoria>().HasKey(Categoria=>Categoria.id);
               builder.Entity<Categoria>().Property(Categoria=>Categoria.id).ValueGeneratedOnAdd();
               builder.Entity<Categoria>().Property(Categoria=>Categoria.nombre).HasColumnName("NombreCompleto");
               builder.Entity<Categoria>().Property(Categoria=>Categoria.nombre).IsRequired().HasMaxLength(30);
               builder.Entity<Categoria>().HasData(
                  new Categoria(){id=1,nombre="Categoria 1"},
                  new Categoria(){id=2,nombre="Categoria 2"},
                  new Categoria(){id=3,nombre="Categoria 3"}
               ); 
            }
        /// <summary>
        ///Representa un objeto de la tabla categoria
        ///Seed de la base (semillas de informacion) -- DB en memoria
        /// </summary>  
        /// <summary>
        ///Metodo para poblar o agregar datos a la base de Datos tabla Categoria
        /// </summary> 
        /*public void PoblarBase()
        {
           this.categorias.Add(
              new Categoria{
                id=1,
                nombre="Categoria 1"
              }
           );
           this.categorias.Add(
              new Categoria{
                id=2,
                nombre="Categoria 2"
              }
           );
        /// <summary>
        ///podria relacionarse como un Comit en base de datos
        /// </summary> 
           this.SaveChanges();
        }*/  
    }
}