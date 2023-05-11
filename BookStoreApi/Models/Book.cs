using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class Book : BaseTable
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PublishingHouse { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category? Category { get; set; }
        public int IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]
        public virtual Author? Author { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
