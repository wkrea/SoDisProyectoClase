using System.Net.Sockets;
using Supermarket.API.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Dominio.Persistencia
{
    /*
     DbContext = permite emular el comportamiento de una db como un orm o manipularla como una clase 
    Dos patrones de diseño 
    1 inyeccion de dependencias,
    2 factory, 
    */
    public class SupermarketApiContext : DbContext
    {
        //CONSTRUCTOR
        //options llegan con el string de coneciion y se definen en el Startup
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {
            //PoblarBase();
            Database.EnsureCreated();
        }
        //TABLAS PROPS DE LA CLASE
        public DbSet<Categoria> categorias { get; set; }

        public DbSet<Producto> productos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            Formas de definir la estructura de la base
            1 Fluent API-- 
            */
            builder.Entity<Categoria>().ToTable("Categirias");
            //              Clase               intancia toma la propiedad id
            builder.Entity<Categoria>().HasKey(Categoria =>Categoria.id);
            builder.Entity<Categoria>().Property(Categoria =>Categoria.id).ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(Categoria =>Categoria.nombre).HasColumnName("NombreCompleto");
            builder.Entity<Categoria>()
                .Property(Categoria =>Categoria.nombre)
                .IsRequired()
                .HasMaxLength(30);
            builder.Entity<Categoria>().HasData(
                new Categoria(){ id = 1 , nombre = "Categoria 1" },
                new Categoria(){ id = 2 , nombre = "Categoria 2" },
                new Categoria(){ id = 3 , nombre = "Categoria 3" }
            );
            
            
            /*
                linq
                listScores.Select(score => score.value>80).ToList();
                                            //linq
                IEnumerable<int> scoreQuery = from score in scores
                                            where score > 80
                                            select score;

                                            // sql
                                            select score
                                            where score > 80
                                            from scores;

            */
            
        }

        // SEED DE LA BASES (SEMILLAS DE INFORMACION)  DB EN MEMORIA
        /*
        public void PoblarBase()
        {
            this.categorias.Add(
                new Categoria{
                    id =1,
                    nombre = "Categoria 1"
                }
            );
            this.categorias.Add(
                new Categoria{
                    id =2,
                    nombre = "Categoria 2"
                }
            );

            //Commit
            this.SaveChanges();
        } 
        */
        
    }   
}