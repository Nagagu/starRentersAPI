using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Models;

namespace StarRentersAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Review>? Reviews { get; set; }

    }
}


