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
using System.Net;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public ReviewController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewForView>>> GetAllReview()
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var reviewList = await _context.Review
                .Where(x => x.IsActive == true)
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Select(y => (ReviewForView)y)
                .ToListAsync();
            return reviewList;
        }

        [HttpGet("GetBookReview/{id}")]
        public async Task<ActionResult<IEnumerable<ReviewForView>>> GetBookReview(int bookId)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(bookId);
            if (book is null)
            {
                return NotFound();
            }

            var reviewList = await _context.Review
                .Where(x => x.IsActive == true && x.IdBook == bookId)
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Select(y => (ReviewForView)y)
                .ToListAsync();
            return reviewList;
        }

        [HttpGet("GetCustomerReview/{id}")]
        public async Task<ActionResult<IEnumerable<ReviewForView>>> GetCustomerReview(int customerId)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(customerId);
            if (customer is null)
            {
                return NotFound();
            }

            var reviewList = await _context.Review
                .Where(x => x.IsActive == true && x.IdCustomer == customerId)
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .Select(y => (ReviewForView)y)
                .ToListAsync();
            return reviewList;
        }

        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewForView>> GetReview(int id)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }
            var review = await _context.Review
                .Where(x => x.IsActive == true && x.Id == id)
                .Include(x => x.Customer)
                .Include(x => x.Book)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            return (ReviewForView)review;
        }

        // PUT: api/Review/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewForView review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            review.MmodifDate = DateTime.Now;
            _context.Entry((Review)review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Review
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReviewForView>> PostReview(ReviewForView review)
        {
            if (_context.Review == null)
            {
                return Problem("Entity set 'BookStoreContext.Review'  is null.");
            }

            review.IsActive = true;
            review.CretionDate = DateTime.Now;
            _context.Review.Add((Review)review);
            await _context.SaveChangesAsync();

            return Ok((ReviewForView)await _context.Review.Include(x => x.Customer).Include(x => x.Book).Where(x => x.Id == review.Id).FirstOrDefaultAsync());
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            if (_context.Review == null)
            {
                return NotFound();
            }
            var review = await _context.Review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            review.IsActive = false;
            review.MmodifDate = DateTime.Now;
            _context.Review.Update(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return (_context.Review?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
