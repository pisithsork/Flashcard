using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flashcards_API.Models;

namespace Flashcards_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardsController : ControllerBase
    {
        private readonly FlashcardDBContext _context;

        public FlashcardsController(FlashcardDBContext context)
        {
            _context = context;
        }

        // GET: api/Flashcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flashcard>>> GetFlashcards()
        {
          if (_context.Flashcards == null)
          {
              return NotFound();
          }
            return await _context.Flashcards.ToListAsync();
        }

        // GET: api/Flashcards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flashcard>> GetFlashcard(int id)
        {
          if (_context.Flashcards == null)
          {
              return NotFound();
          }
            var flashcard = await _context.Flashcards.FindAsync(id);

            if (flashcard == null)
            {
                return NotFound();
            }

            return flashcard;
        }

        // PUT: api/Flashcards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashcard(int id, Flashcard flashcard)
        {
            if (id != flashcard.Id)
            {
                return BadRequest();
            }

            _context.Entry(flashcard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashcardExists(id))
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

        // POST: api/Flashcards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flashcard>> PostFlashcard(Flashcard flashcard)
        {
          if (_context.Flashcards == null)
          {
              return Problem("Entity set 'FlashcardDBContext.Flashcards'  is null.");
          }
            _context.Flashcards.Add(flashcard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlashcard", new { id = flashcard.Id }, flashcard);
        }

        // DELETE: api/Flashcards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcard(int id)
        {
            if (_context.Flashcards == null)
            {
                return NotFound();
            }
            var flashcard = await _context.Flashcards.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }

            _context.Flashcards.Remove(flashcard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlashcardExists(int id)
        {
            return (_context.Flashcards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
