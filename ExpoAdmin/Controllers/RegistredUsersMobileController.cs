using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpoAdmin.Data;

namespace ExpoAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistredUsersMobileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistredUsersMobileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/RegistredUsersMobile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistredUser>> PostRegistredUser(RegistredUser registredUser)
        {
            registredUser.TimeCreated = DateTime.UtcNow;
            _context.RUsers.Add(registredUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistredUser", new { id = registredUser.Id }, registredUser);
        }
    }
}
