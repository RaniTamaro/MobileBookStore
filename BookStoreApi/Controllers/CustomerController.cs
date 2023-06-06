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
    public class CustomerController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public CustomerController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerForView>>> GetCustomer()
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }

            var customerList = await _context.Customer
                .Where(x => x.IsActive == true)
                .Include(x => x.Orders)
                .Select(y => (CustomerForView)y)
                .ToListAsync();

            return customerList;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerForView>> GetCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer
                .Where(x => x.IsActive == true)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return (CustomerForView)customer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerForView customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var customerDb = (Customer)customer;
            customerDb.MmodifDate = DateTime.Now;
            var orderList = new List<Order>();
            foreach (var order in customer.OrdersNumber.ToList())
            {
                orderList.Add(await _context.Order.FindAsync(order.Value));
            }

            customerDb.Orders = orderList;
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerForView>> PostCustomer(CustomerForView customer)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'BookStoreContext.Customer'  is null.");
            }

            var customerDb = (Customer)customer;
            customerDb.MmodifDate = DateTime.Now;
            var orderList = new List<Order>();
            foreach (var order in customer.OrdersNumber.ToList())
            {
                orderList.Add(await _context.Order.FindAsync(order.Value));
            }

            customerDb.Orders = orderList;
            _context.Customer.Add(customerDb);
            await _context.SaveChangesAsync();

            return Ok((CustomerForView)customerDb);
            //return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.IsActive = false;
            customer.MmodifDate = DateTime.Now;
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
