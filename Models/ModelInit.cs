using Microsoft.EntityFrameworkCore;

namespace TestEureca.Models
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookAuthorModel> BookAuthor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskEureka;Username=postgres;Password=Lollord9889");
        }
    }
}