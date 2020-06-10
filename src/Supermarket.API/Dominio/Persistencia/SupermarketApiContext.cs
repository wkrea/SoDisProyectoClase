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
                PoblarBase();
                ///Verificamos que la BD se creó sin ningun tipo de inconveniente
                Database.EnsureCreated();
            }
            ///Tablas (Propiedades de la clase)
            public DbSet<Categoria> categorias {get; set;}
            public DbSet<Producto> productos {get; set;}
            /// Seed de la BD (Semillas de información) - DB en memoria
            public void PoblarBase()
            {
                ///Agregamos las categorias como un vector de acuerdo a los parametros de las categorías
                this.categorias.Add(
                    new Categoria{
                    id=1,
                    nombre = "Categoria 1"
                    }
                );
                this.categorias.Add(
                    new Categoria{
                    id=2,
                    nombre = "Categoria 2"
                    }
                );
                ///Commit: Guarda los cambios realizados a la BD
                this.SaveChanges();
            }
    }

}