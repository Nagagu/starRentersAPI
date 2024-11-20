using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarRentersAPI.Data;
using StarRentersAPI.Models;

namespace StarRentersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TenantController(AppDbContext context)
        {
            _context = context;
        }

        // Obtener un inquilino por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenant>> GetTenant(string id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
        }

        // Crear un nuevo inquilino
        [HttpPost]
        public async Task<ActionResult<Tenant>> CreateTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTenant), new { id = tenant.Id }, tenant);
        }

        // Actualizar un inquilino
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant(string id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tenants.Any(e => e.Id == id))
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

        // Eliminar un inquilino
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(string id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
