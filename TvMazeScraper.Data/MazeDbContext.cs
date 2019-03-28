using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Data.Models;

namespace TvMazeScraper.Data
{
    public class MazeDbContext : DbContext
    {
        public MazeDbContext(DbContextOptions<MazeDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Show>();
            modelBuilder.Entity<Cast>();
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Cast> Casts { get; set; }
    }
}
