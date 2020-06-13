using System.Reflection.Emit;
using System.Reflection;
using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
    /// <summary>
    /// la propiedad Dbcontext permite representar o simular en la base de datos funcionando como una clase 
    /// </summary>
    public class SupermarketApiContext : DbContext
    {
      //constructor
      /// <summary>
      /// opciones que posee el string de conexion y se utilizan para emparejar los servicios que serviran pra correr la aplicacion 
      /// </summary>
      /// <param name="options"></param>
      /// <returns></returns>

      public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
      {   
        //PoblarBase();
        Database.EnsureCreated();       
      }
      /// <summary>
      /// tablas "propiedades de la clase" conocidas como nombre de dominio
      /// </summary>
      /// <value></value>
      public DbSet<Categoria> categorias {get; set;}
      /// <summary>
      /// Tabla que representa el producto
      /// </summary>
      /// <value></value>
      public DbSet<Productos> productos {get; set;}
      //see de la base (semillas de informacion) --DB memory
      /// <summary>
      ///esta es la fabrica de la base de datos patron de fabrica es un patron de fabrica, creando una instancia de superMarketapi
      /// </summary>
      protected override void OnModelCreating(ModelBuilder builder) 
      {
        //fluen API
        
        builder.Entity<Categoria>().ToTable("Categorias");
        //categoria es un objeto de esta clase, de la instancia categoria tome lo que hy en categoria y luego tome el id y eso se convertira en llave (key)
        builder.Entity<Categoria>().HasKey(categorias =>  categorias.id);
        builder.Entity<Categoria>().Property(categorias => categorias.id).ValueGeneratedOnAdd();
        builder.Entity<Categoria>().Property(categorias => categorias.nombre).HasColumnName("NombreCompleto");
        builder.Entity<Categoria>().Property(categorias => categorias.nombre).IsRequired().HasMaxLength(30);
      

        builder.Entity<Categoria>().HasData(
            new Categoria(){ id = 1, nombre = "Categoria 1"},
            new Categoria(){ id = 2, nombre = "Categoria 2"},
            new Categoria(){ id = 2, nombre = "Categoria 3"}
        );
        

          //esto es una explicacion colombiana de linq 
        // listScores.Select(score => score.value > 80).ToList();

        // IEnumerable<int> acoreQuery = from score in scores
        //                               where score > 80
        //                               select score;

        //                               //sql
        //                               select score
        //                               where score > 80
        //                               from scores;


      }

      // public void PoblarBase()
      // {
      //   this.categorias.AddAsync(
      //     new Categoria{
      //         id = 1,
      //         nombre = "Categoria 1"
      //     }
      //   );
      //   this.categorias.AddAsync(
      //     new Categoria{
      //         id = 2,
      //         nombre = "Categoria 2"
      //     }
      //   );
      //   //commit 
      //   this.SaveChanges();

      // }
    }
}