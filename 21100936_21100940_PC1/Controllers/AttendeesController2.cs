using EventManagementDB.DOMAIN.Core.Entidades;
using EventManagementDB.DOMAIN.Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _21100936_21100940_PC1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController2 : ControllerBase
    {
        private readonly EventManagementDbContext _context;
        public AttendeesController2(EventManagementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendees>>> GetAttendees()
        {
            return await _context.Attendees.ToListAsync();
        }

        //CREATE

        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<Attendees>> PostAttendees(Attendees attendees)
        {
            _context.Attendees.Add(attendees);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendees", new { id = attendees.Id }, attendees);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendees(int id)
        {
            var result = await _context.Attendees.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
