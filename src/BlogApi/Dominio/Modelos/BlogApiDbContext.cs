using Microsoft.EntityFrameworkCore;

namespace BlogApi.Dominio.Modelos
{
    public class BlogApiDbContext : DbContext
    {
        public BlogApiDbContext(DbContextOptions<BlogApiDbContext> options) : base(options) {}

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}