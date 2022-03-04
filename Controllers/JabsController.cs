# nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectManage.Data;
using ProjectManage.Models;
using ProjectManage.Account;

namespace ProjectManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JabsController : ControllerBase
    {
        private readonly PMDbContext _context;

        public JabsController(PMDbContext context)
        {
            _context = context;
        }

        // Get: api/Jabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jab>>> GetJabsItems()
        {
            return await _context.Jabs.ToListAsync();
        }

        // Get: api/Jabs/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Jab>> GetJabItem(int id)
        {
            var j = await _context.Jabs.FindAsync(id);

            if(j == null)
                return NotFound();
            return j;
        }

        // Put: api/jabs/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJabItem(int id, Jab ja)
        {
            if (id != ja.Id)
                return BadRequest();

            _context.Entry(ja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JabExists(id))
                {
                    return NotFound();
                }
                else
                    throw;
            }

            return NoContent();
        }

        // Post: api/jabs
        [HttpPost]
        public async Task<ActionResult<Jab>> PostJab(Jab ja)
        {
            _context.Jabs.Add(ja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJabItem), new { Id = ja.Id }, ja);
        }

        // Delete api/jab/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJabItem(int id)
        {
            var ja = await _context.Jabs.FindAsync(id);
            if (ja == null)
                return NotFound();
            
            _context.Jabs.Remove(ja);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool JabExists(int id)
        {
            return _context.Jabs.Any(e => e.Id == id);
        }
    }
}