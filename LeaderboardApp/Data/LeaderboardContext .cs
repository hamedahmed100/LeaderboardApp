using LeaderboardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderboardApp.Data
{
    public class LeaderboardContext : DbContext
    {
        public LeaderboardContext(DbContextOptions<LeaderboardContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Counter> Counters { get; set; }
    }
}
