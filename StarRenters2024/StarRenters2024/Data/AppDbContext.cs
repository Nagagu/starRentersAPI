using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Models;

namespace StarRentersAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; } // DbSet para la entidad Tenant

        // Puedes añadir otros DbSets si tienes más entidades, por ejemplo, Reviews
        public DbSet<Review> Reviews { get; set; }
    }
}
