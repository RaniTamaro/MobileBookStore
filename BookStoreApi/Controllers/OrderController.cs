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
    public class OrderController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public OrderController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderForView>>> GetOrder()
        {
            if (_context.Order == null)
            {
                return NotFound();
            }

            var orderList = await _context.Order
                .Where(x => x.IsActive == true)
                .Include(x => x.OrderBooks).ThenInclude(g => g.Book).Include(x => x.User)
                .Select(y => (OrderForView)y)
                .ToListAsync();

            return orderList;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderForView>> GetOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order
                .Where(x => x.IsActive == true)
                .Include(x => x.OrderBooks).ThenInclude(g => g.Book).Include(x => x.User)
                .FirstOrDefaultAsync(); ;

            if (order == null)
            {
                return NotFound();
            }

            return (OrderForView)order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderForView order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var orderDb = (Order)order;
            orderDb.MmodifDate = DateTime.Now;
            var orderBookList = new List<OrderBook>();
            if(order.OrderBook != null)
            {
                foreach (var book in order.OrderBook)
                {
                    var existOrderBook = await _context.OrderBook.Where(x => x.IsActive == true && x.IdOrder == orderDb.Id && x.IdBook == book.Id).FirstOrDefaultAsync();
                    orderBookList.Add(existOrderBook == null ?
                        new OrderBook
                        {
                            IdOrder = orderDb.Id,
                            Order = orderDb,
                            IdBook = book.Id,
                            Book = await _context.Book.FindAsync(book.Id)
                        }
                    : existOrderBook);
                }
            }

            orderDb.OrderBooks = orderBookList;
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderForView>> PostOrder(OrderForView order)
        {
            if (_context.Order == null)
            {
                return Problem("Entity set 'BookStoreContext.Order'  is null.");
            }

            var orderDb = (Order)order;
            _context.Order.Add(orderDb);
            await _context.SaveChangesAsync();

            var orderBookList = new List<OrderBook>();
            if (order.OrderBook != null)
            {
                foreach (var book in order.OrderBook)
                {
                    orderBookList.Add(new OrderBook
                    {
                        IdOrder = orderDb.Id,
                        Order = orderDb,
                        IdBook = book.Id,
                        Book = await _context.Book.FindAsync(book.Id)
                    });
                }
            }

            orderDb.OrderBooks = orderBookList;
            _context.Order.Update(orderDb);
            await _context.SaveChangesAsync();
            return Ok((OrderForView)orderDb);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.IsActive = false;
            order.MmodifDate = DateTime.Now;

            _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
