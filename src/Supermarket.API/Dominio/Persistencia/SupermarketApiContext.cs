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
            /* PoblarBase(); */
            Database.EnsureCreated(); 
        }
        //tablas 

        /// <summary>
        /// Dataset de la base de datos que representa Categoria
        /// </summary>
        /// <value></value>
        public DbSet<Categoria> categorias {get; set; }
        
        /// <summary>
        /// Dataset de la base de datos que representa Producto
        /// </summary>
        /// <value></value>
        public DbSet<Producto> productos {get; set; }
        
        /// <summary>
        /// Fabrica Base de datos
        /// Equivalente al metodo deonde agregamos los Seeds
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Fluent Api

           /*  builder.Entity<Categoria>().ToTable("categorias");
            builder.Entity<Categoria>().HasKey(categoria => categoria.id);
            builder.Entity<Categoria>().Property(categoria => categoria.id).ValueGeneratedOnAdd();
            builder.Entity<Categoria>().Property(categoria => categoria.nombre).HasColumnName("NumbreCompleto");
            builder.Entity<Categoria>()
                    .Property(categoria => categoria.nombre)
                    .IsRequired()
                    .HasMaxLength(30); */
            
            builder.Entity<Categoria>().HasData(
                new Categoria(){ id = 1, nombre = "categoria 1"},
                new Categoria(){ id = 2, nombre = "categoria 2"},
                new Categoria(){ id = 3, nombre = "categoria 3"}
            );
            
             
        }
            //Explicacion de LinQ
            /* listScores.select(score => score.value > 80).ToList();
            IEnumerable<int> scoreQuery = from score in scores
                                            where score > 80
                                            select score;

                                        //sql

                                        select score
                                        where score > 80
                                        from scores; */






        //seed (DB memoria)

        /// <summary>
        /// Seed de la base de datos
        /// </summary>
        /* public void PoblarBase()
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
        } */


    }
}