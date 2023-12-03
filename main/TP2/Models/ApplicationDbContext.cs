using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre> genres { get; set; }
        public ApplicationDbContext(DbContextOptions options)
:       base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API configuration for the relationship
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId);
    }
    }
}
