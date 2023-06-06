using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreApi.Data;
using BookStoreApi.Models;
using BookStoreApi.ViewModels;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public AuthorController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorForView>>> GetAuthor()
        {
            if (_context.Author == null)
            {
                return NotFound();
            }

            var authorList = await _context.Author
                .Where(x => x.IsActive == true)
                .Include(x => x.Books)
                .Select(y => (AuthorForView)y)
                .ToListAsync();

            return authorList;
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorForView>> GetAuthor(int id)
        {
            if (_context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author
                .Where(x => x.IsActive == true && x.Id == id)
                .Include(x => x.Books)
                .FirstOrDefaultAsync();
            if (author == null)
            {
                return NotFound();
            }

            return (AuthorForView)author;
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorForView author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }


            var authorDb = (Author)author;
            authorDb.MmodifDate = DateTime.Now;
            var bookList = new List<Book>();
            foreach (var book in author.Books.ToList())
            {
                bookList.Add(await _context.Book.FindAsync(book.Value));
            }

            authorDb.Books = bookList;
            _context.Entry(authorDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorForView>> PostAuthor(AuthorForView author)
        {
            if (_context.Author == null)
            {
                return Problem("Entity set 'BookStoreContext.Author'  is null.");
            }

            var authorDb = (Author)author;
            var bookList = new List<Book>();
            foreach (var book in author.Books.ToList())
            {
                bookList.Add(await _context.Book.FindAsync(book.Value));
            }

            authorDb.Books = bookList;
            _context.Author.Add(authorDb);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
            return Ok((AuthorForView)authorDb);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_context.Author == null)
            {
                return NotFound();
            }
            var author = await _context.Author.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.IsActive = false;
            author.MmodifDate = DateTime.Now;
            _context.Author.Update(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return (_context.Author?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
