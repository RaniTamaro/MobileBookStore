using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookStoreApi.Models.Author> Author { get; set; } = default!;

        public DbSet<BookStoreApi.Models.Book>? Book { get; set; }

        public DbSet<BookStoreApi.Models.Category>? Category { get; set; }

        public DbSet<BookStoreApi.Models.User>? User { get; set; }

        public DbSet<BookStoreApi.Models.Genre>? Genre { get; set; }

        public DbSet<BookStoreApi.Models.Order>? Order { get; set; }

        public DbSet<BookStoreApi.Models.Review>? Review { get; set; }

        public DbSet<BookStoreApi.Models.BookGenre>? BookGenre { get; set; }
        public DbSet<BookStoreApi.Models.OrderBook>? OrderBook { get; set; }
    }
}
