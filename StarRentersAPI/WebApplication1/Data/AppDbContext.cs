using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Models; // Asegúrate de incluir tu modelo

namespace StarRentersAPI.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor que pasa la configuración del contexto a la clase base
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aquí defines las tablas en tu base de datos
        public DbSet<Review> Reviews { get; set; }
    }
}
