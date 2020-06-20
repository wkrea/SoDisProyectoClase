using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
namespace Supermarket.API.Dominio.Persistencia
{
    public class SupermarketApiContext : DbContext
    {
        public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
        {

        }

        public DbSet<Categoria> categorias {get; set;}
        public DbSet<Producto> productos {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categoria>().ToTable("categorias");
            builder.Entity<Categoria>().HasKey(Categoria => Categoria.id);
            builder.Entity<Categoria>().Property(Categoria => Categoria.id).ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(Categoria => Categoria.nombre).HasColumnName("NombreCompleto");
            builder.Entity<Categoria>()
                .Property(categoria => categoria.nombre)
                .IsRequired()
                .HasMaxLength(30);
            builder.Entity<Categoria>().HasData(
                new Categoria() {id =1, nombre = "categoria 1"},
                new Categoria() {id = 2, nombre= "categoria 2"},
                new Categoria() {id= 3, nombre = "Categoria 3"}
            );

        }

            //Esto es una explicacion muy colombiana del LINQ
            //listScores.Select(score => 80).Tolist();
            // linq
            
           // IEnumerable<int> scoreQuery = from score in scores
           //                             where score > 80
            //select score;

        




        // seed de la base (Semillas)
         public void poblarBase()
        {
            this.categorias.Add(
                new Categoria {
                    id = 1,
                    nombre = "categoria 1"
                }
            );
            this.categorias.Add(
                new Categoria {
                    id = 2,
                    nombre = "categoria 2"
                }
            );
            // con esto se tiene una base de datos poblada
            this.SaveChanges();

        }




    }
}