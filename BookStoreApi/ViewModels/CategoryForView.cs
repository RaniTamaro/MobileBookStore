using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApi.ViewModels
{
    public class CategoryForView : BaseTable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual List<SelectListItem> Books { get; set; }

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
