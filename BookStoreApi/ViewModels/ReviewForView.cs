using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.ViewModels
{
    public class ReviewForView : BaseTable
    {
        public double Rating { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int IdUser { get; set; }
        public virtual string? UserFullName { get; set; }
        public int IdBook { get; set; }
        public virtual string? BookTitle { get; set; }

        public static explicit operator Review(ReviewForView forView)
        {
            var result = new Review
            {

            }.CopyProperties(forView);
            return result;
        }

        public static explicit operator ReviewForView(Review entity)
        {
            var result = new ReviewForView
            {
                UserFullName = $"{entity?.User?.Name} {entity?.User?.Surname}",
                BookTitle = entity?.Book?.Title ?? string.Empty
            }.CopyProperties(entity);
            return result;
        }
    }
}
