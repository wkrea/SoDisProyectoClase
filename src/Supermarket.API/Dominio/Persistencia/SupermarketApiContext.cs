using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Dominio.Persistencia
{
	public class SupermarketApiContext : DbContext
	{
	//constructor
	public SupermarketApiContext(DbContextOptions<SupermarketApiContext> options) : base(options)
	{
	}
	//Tablas "props de la clase"
	public DbSet<Categoria> categorias { get; set; }
	public DbSet<Producto> productos { get; set; }
	
	//seed de la base (semillas de informacion) -- DB en memoria

	}
}
