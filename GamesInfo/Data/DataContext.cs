using GamesInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesInfo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStudio> GameStudios { get; set; }
        public DbSet<GameСategory> GameСategories { get; set; }
    }
}
