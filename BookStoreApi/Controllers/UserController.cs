using BookStoreApi.Data;
using BookStoreApi.Models;
using BookStoreApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookStoreContext _context;

        public UserController(BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet("Login/nickname={nickname}/password={password}")]
        public async Task<ActionResult<UserForView>> Login(string nickname, string password)
        {
            var login = await _context.User.Where(x => x.Nickname == nickname && x.Password == password).SingleOrDefaultAsync();

            if (login is null)
            {
                return new UserForView();
            }

            return (UserForView)login;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserForView>>> GetUser()
        {
            if (_context.User == null)
            {
                return NotFound();
            }

            var userList = await _context.User
                .Where(x => x.IsActive == true)
                .Include(x => x.Orders)
                .Select(y => (UserForView)y)
                .ToListAsync();

            return userList;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserForView>> GetUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User
                .Where(x => x.IsActive == true)
                .Include(x => x.Orders)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return (UserForView)user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserForView user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var userDb = (User)user;
            userDb.MmodifDate = DateTime.Now;
            var orderList = new List<Order>();
            foreach (var order in user.Orders.ToList())
            {
                orderList.Add(await _context.Order.FindAsync(order.Number));
            }

            userDb.Orders = orderList;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserForView>> PostUser(UserForView user)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'BookStoreContext.User'  is null.");
            }

            var userDb = (User)user;
            userDb.MmodifDate = DateTime.Now;
            var orderList = new List<Order>();
            foreach (var order in user.Orders.ToList())
            {
                orderList.Add(await _context.Order.FindAsync(order.Number));
            }

            userDb.Orders = orderList;
            _context.User.Add(userDb);
            await _context.SaveChangesAsync();

            return Ok((UserForView)userDb);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = false;
            user.MmodifDate = DateTime.Now;
            _context.User.Update(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
