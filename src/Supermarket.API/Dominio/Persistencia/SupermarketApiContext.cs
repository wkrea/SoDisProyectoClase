using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
	public class SupermarketApiContext : DbContext
	{
	//constructor

	public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
	{
		//PoblarBase();
		Database.EnsureCreated();
	}
	//Tablas "props de la clase"
	public DbSet<Categoria> categorias { get; set; }
	public DbSet<Producto> productos { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		//fluent API
		builder.Entity<Categoria>().ToTable("Categorias");
		builder.Entity<Categoria>().HasKey(categoria => categoria.id);
		builder.Entity<Categoria>().Property(categoria => categoria.id).ValueGeneratedOnAdd();
		builder.Entity<Categoria>().Property(categoria => categoria.nombre).HasColumnName("NombreCompleto");
		builder.Entity<Categoria>().Property(categoria => categoria.nombre).IsRequired().HasMaxLength(30);

		builder.Entity<Categoria>().HasData(
			new Categoria(){ id =1, nombre = "Categoria 1" },
			new Categoria(){ id =2, nombre = "Categoria 2" },
			new Categoria(){ id =3, nombre = "Categoria 3" }
		);
	}
	
	//seed de la base (semillas de informacion) -- DB en memoria

	// public void PoblarBase()
	// {
	// 	this.categorias.Add(
	// 		new Categoria{
	// 			id = 1,
	// 			nombre = "Categoria 1"
	// 		}
	// 	);

	// 	this.categorias.Add(
	// 		new Categoria{
	// 			id = 2,
	// 			nombre = "Categoria 2"
	// 		}
	// 	);

	// 	///commit
	// 	this.SaveChanges();

	// }

	}
}
