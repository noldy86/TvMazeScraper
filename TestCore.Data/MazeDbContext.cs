using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestCore.Data.Models;

namespace TestCore.Data
{
    public class MazeDbContext : DbContext
    {
        public MazeDbContext(DbContextOptions<MazeDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Show> Shows { get; set; }
    }
}
