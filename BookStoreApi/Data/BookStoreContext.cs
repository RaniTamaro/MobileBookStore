using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreApi.Models;

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

        public DbSet<BookStoreApi.Models.User>? Customer { get; set; }

        public DbSet<BookStoreApi.Models.Genre>? Genre { get; set; }

        public DbSet<BookStoreApi.Models.Order>? Order { get; set; }

        public DbSet<BookStoreApi.Models.Report>? Report { get; set; }
        public DbSet<BookStoreApi.Models.Review>? Review { get; set; }

        public DbSet<BookStoreApi.Models.BookGenre>? BookGenre { get; set; }
        public DbSet<BookStoreApi.Models.OrderBook>? OrderBook { get; set; }
    }
}
