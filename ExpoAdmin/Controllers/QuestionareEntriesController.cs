using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpoAdmin.Data;
using System;

namespace ExpoAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionareEntriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionareEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionareEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionareEntry>>> GetEntries()
        {
            return await _context.Entries.Include(O => O.Questions).ToListAsync();
        }

        // GET: api/QuestionareEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionareEntry>> GetQuestionareEntry(int id)
        {
            var questionareEntry = await _context.Entries.FindAsync(id);

            if (questionareEntry == null)
            {
                return NotFound();
            }

            return questionareEntry;
        }

        //// PUT: api/QuestionareEntries/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuestionareEntry(int id, QuestionareEntry questionareEntry)
        //{
        //    if (id != questionareEntry.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(questionareEntry).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionareEntryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/QuestionareEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionareEntry>> PostQuestionareEntry(QuestionareEntry questionareEntry)
        {
            questionareEntry.TimeCreated = DateTime.UtcNow;
            foreach (var item in questionareEntry.Questions)
            {
                item.TimeCreated = DateTime.UtcNow;
            }
            _context.Entries.Add(questionareEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionareEntry", new { id = questionareEntry.Id }, questionareEntry);
        }

        //// DELETE: api/QuestionareEntries/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuestionareEntry(int id)
        //{
        //    var questionareEntry = await _context.Entries.FindAsync(id);
        //    if (questionareEntry == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Entries.Remove(questionareEntry);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool QuestionareEntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
