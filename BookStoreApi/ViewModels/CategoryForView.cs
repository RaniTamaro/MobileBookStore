using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;

namespace BookStoreApi.ViewModels
{
    public class CategoryForView : BaseTable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<BookForView>? Books { get; set; }

        public static explicit operator Category(CategoryForView forView)
        {
            var result = new Category
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator CategoryForView(Category entity)
        {
            var result = new CategoryForView
            {
                Books = entity.Books.Select(x => (BookForView)x).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
