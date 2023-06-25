using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;

namespace BookStoreApi.ViewModels
{
    public class BookForView : BaseTable
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? PublishingHouse { get; set; }
        public decimal Price { get; set; }
        public int IdCategory { get; set; }
        public virtual string? CategoryName { get; set; }
        public int IdAuthor { get; set; }
        public virtual string? AuthorName { get; set; }
        public virtual ICollection<Genre> BookGenres { get; set; }

        public static explicit operator Book(BookForView forView)
        {
            var result = new Book
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator BookForView(Book entity)
        {
            var result = new BookForView
            {
                AuthorName = !string.IsNullOrEmpty(entity?.Author?.Name) ? $"{entity?.Author?.Name} {entity?.Author?.Surname}" : entity?.Author?.Nickname,
                CategoryName = entity?.Category?.Name,
                BookGenres = entity?.BookGenres?.Select(y => y.Genre).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
