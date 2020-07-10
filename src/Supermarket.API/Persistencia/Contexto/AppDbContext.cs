using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Supermarket.API.Dominio.Entidades;

namespace Supermarket.API.Persistencia.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categories { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(p => p.id);
            builder.Entity<Categoria>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Categoria>().Property(p => p.nombre).IsRequired().HasMaxLength(30);
            builder.Entity<Categoria>().HasMany(p => p.productos).WithOne(p => p.categoria).HasForeignKey(p => p.categoriaId);

            builder.Entity<Categoria>().HasData
            (
                new Categoria { id = 100, nombre = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Categoria { id = 101, nombre = "Dairy" }
            );

            builder.Entity<Producto>().ToTable("Productos");
            builder.Entity<Producto>().HasKey(p => p.id);
            builder.Entity<Producto>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Producto>().Property(p => p.nombre).IsRequired().HasMaxLength(50);
            builder.Entity<Producto>().Property(p => p.cantXpaquete).IsRequired();
            builder.Entity<Producto>().Property(p => p.unidadDMedida).IsRequired();

            builder.Entity<Producto>().HasData
            (
                new Producto
                {
                    id = 100,
                    nombre = "Apple",
                    cantXpaquete = 1,
                    unidadDMedida = EUndMedida.und,
                    categoriaId = 100
                },
                new Producto
                {
                    id = 101,
                    nombre = "Milk",
                    cantXpaquete = 2,
                    unidadDMedida = EUndMedida.L,
                    categoriaId = 101,
                }
            );
        }
    }
}