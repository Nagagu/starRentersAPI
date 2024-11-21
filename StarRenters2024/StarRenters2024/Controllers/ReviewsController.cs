using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Data;
using StarRentersAPI.Models;

namespace StarRenters2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todas las reseñas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            // Si no existe ningún problema de nullabilidad en _context.Reviews, se devuelve sin problemas
            return await _context.Reviews.ToListAsync();
        }

        // Obtener una reseña por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            // Comprobamos si la reseña no existe, devolvemos 404
            if (review == null)
            {
                return NotFound();
            }

          
            return review!;
        }

        [HttpGet("byTenantName/{tenantName}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByTenant(string tenantName)
        {
            var reviews = await _context.Reviews
                .Where(r => r.TenantName.ToLower().Contains(tenantName.ToLower()))
                .ToListAsync();

            if (reviews == null || !reviews.Any())
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        // Crear una nueva reseña
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(Review review)
        {
            // Se añade la reseña y se guarda, como review se pasa como parámetro no debería ser null
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            // Retorna el objeto con el estado correcto
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // Actualizar una reseña existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Eliminar una reseña y devolver la lista actualizada
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Review>>> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            // Devolver todas las reseñas restantes
            return await _context.Reviews.ToListAsync();
        }


        private bool ReviewExists(int id)
        {
            // En este caso, la consulta se hace con el método Any que devuelve un booleano, no hay posibilidad de null
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
