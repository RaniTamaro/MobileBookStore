using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApi.ViewModels
{
    public class AuthorForView : BaseTable
    {
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public virtual List<SelectListItem> Books { get; set; }

        public static explicit operator Author(AuthorForView forView)
        {
            var result = new Author
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator AuthorForView(Author entity)
        {
            var result = new AuthorForView
            {
                Books = entity.Books.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                }).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
