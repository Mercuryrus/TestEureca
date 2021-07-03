using Microsoft.EntityFrameworkCore;

namespace TestEureca.Models
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<BookModel> Book { get; set; }
        public DbSet<AuthorModel> Author { get; set; }
        public DbSet<BookAuthorModel> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskEureka;Username=postgres;Password=Lollord9889");
        }
    }
}