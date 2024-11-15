using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Data;  // Asegúrate de importar tu AppDbContext
using StarRentersAPI.Models;

namespace StarRentersAPI.Services
{
    public class ReviewService
    {
        private readonly AppDbContext _context;

        // Constructor para inyectar el AppDbContext
        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        // Método para obtener todas las reseñas
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        // Método para agregar una nueva reseña
        public async Task AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        // Otros métodos según sea necesario, por ejemplo, actualizar o eliminar reseñas.
    }
}
