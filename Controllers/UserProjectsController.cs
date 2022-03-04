#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManage.Data;
using ProjectManage.Models;

namespace ProjectManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectsController : ControllerBase
    {
        private readonly PMDbContext _context;

        public UserProjectsController(PMDbContext context)
        {
            _context = context;
        }

        // GET: api/UserProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProject>>> GetUserProject()
        {
            return await _context.UserProject
                .Include(c => c.Project)
                .Include(x => x.User)
                .ToListAsync();
        }

        // GET: api/UserProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProject>> GetUserProject(int id)
        {
            var userProject = await _context.UserProject.FindAsync(id);

            if (userProject == null)
            {
                return NotFound();
            }

            return userProject;
        }

        // PUT: api/UserProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProject(int id, UserProject userProject)
        {
            if (id != userProject.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(userProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProjectExists(id))
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

        // POST: api/UserProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserProject>> PostUserProject(UserProject userProject)
        {
            _context.UserProject.Add(userProject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserProjectExists(userProject.ProjectId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserProject", new { id = userProject.ProjectId }, userProject);
        }

        // DELETE: api/UserProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProject(int id)
        {
            var userProject = await _context.UserProject.FindAsync(id);
            if (userProject == null)
            {
                return NotFound();
            }

            _context.UserProject.Remove(userProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProjectExists(int id)
        {
            return _context.UserProject.Any(e => e.ProjectId == id);
        }
    }
}
