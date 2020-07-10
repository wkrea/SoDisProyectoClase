using System.Collections.Generic;
using Supermarket.API.Dominio.Entidades;

namespace xTest.Modelos
{
    public class DBInicializar
    {
        private readonly TestApiContext _db;
        public DBInicializar(TestApiContext context) 
        {
            _db = context;
        }

        public void Seed()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();

            // _db.categorias.AddRangeAsync(
            //     new Categoria() { id=1, nombre = "categoria 1" },
            //     new Categoria() { id=2, nombre = "categoria 2" },
            //     new Categoria() { id=3, nombre = "categoria 3"},
            //     new Categoria() { id=4, nombre = "categoria 4"}
            // );
            
            // _db.productos.AddRange(new List<Producto>(){
            //     new Producto() { id=1001, nombre = "prod 1",  categoriaId = 1}, // , CreatedDate = DateTime.Now },
            //     new Producto() { id=2001, nombre = "Prod 2",  categoriaId = 3}  //, CreatedDate = DateTime.Now }
            // });
            // _db.SaveChanges();

        }
    }
}