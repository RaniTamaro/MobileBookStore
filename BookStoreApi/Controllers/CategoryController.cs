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
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public CategoryController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryForView>>> GetCategory()
        {
            if (_context.Category == null)
            {
                return NotFound();
            }

            var categoryList = await _context.Category
                .Where(x => x.IsActive == true)
                .Include(x => x.Books)
                .Select(y => (CategoryForView)y)
                .ToListAsync();

            return categoryList;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryForView>> GetCategory(int id)
        {
          if (_context.Category == null)
          {
              return NotFound();
          }
            var category = await _context.Category
                .Where(x => x.IsActive == true && x.Id == id)
                .Include(x => x.Books)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            return (CategoryForView)category;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryForView category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var categoryDb = (Category)category;
            categoryDb.MmodifDate = DateTime.Now;
            var bookList = new List<Book>();
            foreach (var book in category.Books.ToList())
            {
                bookList.Add(await _context.Book.FindAsync(book.Title));
            }

            categoryDb.Books = bookList;
            _context.Entry(categoryDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryForView>> PostCategory(CategoryForView category)
        {
          if (_context.Category == null)
          {
              return Problem("Entity set 'BookStoreContext.Category'  is null.");
          }
            var categoryDb = (Category)category;
            var bookList = new List<Book>();
            foreach (var book in category.Books.ToList())
            {
                bookList.Add(await _context.Book.FindAsync(book.Title));
            }

            categoryDb.Books = bookList;
            _context.Category.Add(categoryDb);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            return Ok((CategoryForView)categoryDb);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsActive = false;
            category.MmodifDate = DateTime.Now;
            _context.Category.Update(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
