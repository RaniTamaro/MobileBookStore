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
using BookStoreApi.ViewModels.Helpers;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public BookController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookForView>>> GetBook()
        {
            if (_context.Book == null)
            {
                return NotFound();
            }

            var bookList = await _context.Book
                .Where(x => x.IsActive == true)
                .Include(x => x.BookGenres).ThenInclude(g => g.Genre).Include(x => x.Category).Include(x => x.Author)
                .Select(y => (BookForView)y)
                .ToListAsync();

            return bookList;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookForView>> GetBook(int id)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Where(x => x.IsActive == true && x.Id == id)
                .Include(x => x.BookGenres).ThenInclude(g => g.Genre).Include(x => x.Category).Include(x => x.Author)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return (BookForView)book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookForView book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var bookDb = (Book)book;
            bookDb.MmodifDate = DateTime.Now;
            var bookGenreList = new List<BookGenre>();
            foreach (var genre in book.BookGenres)
            {
                var existBookGenre = await _context.BookGenre.Where(x => x.IsActive == true && x.IdBook == bookDb.Id && x.IdGenre == genre.Id).FirstOrDefaultAsync();
                bookGenreList.Add(existBookGenre == null ?
                    new BookGenre
                    {
                        IdBook = bookDb.Id,
                        Book = bookDb,
                        IdGenre = genre.Id,
                        Genre = await _context.Genre.FindAsync(genre.Id)
                    }
                : existBookGenre);
            }

            bookDb.BookGenres = bookGenreList;
            _context.Entry(bookDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookForView>> PostBook(BookForView book)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookStoreContext.Book'  is null.");
            }

            var bookDb = (Book)book;
            _context.Book.Add(bookDb);
            await _context.SaveChangesAsync();

            var bookGenreList = new List<BookGenre>();
            if (book.BookGenres != null)
            {
                foreach (var genre in book.BookGenres)
                {
                    bookGenreList.Add(new BookGenre
                    {
                        IdBook = bookDb.Id,
                        Book = bookDb,
                        IdGenre = genre.Id,
                        Genre = await _context.Genre.FindAsync(genre.Id)
                    });
                }
            }

            bookDb.BookGenres = bookGenreList;
            _context.Book.Update(bookDb);
            await _context.SaveChangesAsync();
            return Ok((BookForView)bookDb);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Book == null)
            {
                return NotFound();
            }
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.IsActive = false;
            book.MmodifDate = DateTime.Now;

            _context.Book.Update(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
