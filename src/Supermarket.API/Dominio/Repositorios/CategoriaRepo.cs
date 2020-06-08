using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Persistencia;

using Supermarket.API.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API.Dominio.Repositorios
{
    public class CategoriaRepo : ICategoriaRepo
    {
        private readonly SupermarketApiContext db;

        public CategoriaRepo(SupermarketApiContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Categoria>> ListAsync()
        {
            // https://markheath.net/post/async-antipatterns
            // https://www.campusmvp.es/recursos/post/async-y-await-en-c-como-manejar-asincronismo-en-net-de-manera-facil.aspx
            // https://docs.microsoft.com/en-us/ef/core/querying/async
            // https://www.learnentityframeworkcore.com/walkthroughs/aspnetcore-application

            List<Categoria> lista;
            lista = await db.Categorias.AsNoTracking().ToListAsync();
            return lista;
        }
    }
}