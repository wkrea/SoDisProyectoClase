using System;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
    /// <summary>
    /// Se define la clase para emular una BD relacionar
    /// Aquí se emula la base de datos como si fuese una clase
    /// en este caso deriba de DbContext que es quien se encarga de manipular la base
    /// </summary>
    public class SupermarketApiContext : DbContext
    {
            /// Constructo 
            public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base (options)
            {
                ///Iniciamos la BD creada en el metodo PoblarBase, para que se cree en el contructor
                //PoblarBase();
                ///Verificamos que la BD se creó sin ningun tipo de inconveniente
                Database.EnsureCreated();
            }
            ///Tablas (Propiedades de la clase)
            public DbSet<Categoria> categorias {get; set;}
            public DbSet<Producto> productos {get; set;}
            /// <summary>
            /// Metodo en donde creo o construyo la BD - Usamos Fuent API
            protected override void OnModelCreating(ModelBuilder builder)
            {
                // Fluent API
                /// Se construye la tabla, se define como una instancia de Categoria, y se asignan las propiedades a la BD
                builder.Entity<Categoria>().ToTable("Categorias");
                /// Se asigna la llave de la tabla, indicando cual es el atributo del objeto que le corresponde a este campo
                builder.Entity<Categoria>().HasKey(categoria => categoria.id);
                /// Indico que el id es un autoincremental 
                builder.Entity<Categoria>().Property(categoria => categoria.id).ValueGeneratedOnAdd();
                /// Asigno un nombre a la columna de la nueva tabla para el valor nombre de la categoría
                builder.Entity<Categoria>().Property(categoria => categoria.nombre).HasColumnName("NombreCompleto");
                /// indicamos que el nombre de la categoría es requerido
                builder.Entity<Categoria>().Property(categoria => categoria.nombre).IsRequired().HasMaxLength(30);
                /// Creamos la semilla de la BD -> Valores 
                builder.Entity<Categoria>().HasData(
                    new Categoria(){id=1, nombre="Categoria 1"},
                    new Categoria(){id=2, nombre="Categoria 2"},
                    new Categoria(){id=3, nombre="Categoria 3"}
                );                         
            }
          //  /// Seed de la BD (Semillas de información) - DB en memoria
          //  public void PoblarBase()
          //  {
          //      ///Agregamos las categorias como un vector de acuerdo a los parametros de las categorías
          //      this.categorias.Add(
          //          new Categoria{
          //          id=1,
          //          nombre = "Categoria 1"
          //          }
          //      );
          //      this.categorias.Add(
          //          new Categoria{
          //          id=2,
          //          nombre = "Categoria 2"
          //          }
          //      );
          //      ///Commit: Guarda los cambios realizados a la BD
          //      this.SaveChanges();
          //  }
    }

}