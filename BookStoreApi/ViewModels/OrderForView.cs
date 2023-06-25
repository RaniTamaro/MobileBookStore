using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;

namespace BookStoreApi.ViewModels
{
    public class OrderForView : BaseTable
    {
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public string Address { get; set; }
        public string? Status { get; set; }
        public string? TrackingNumber { get; set; }
        public int IdUser { get; set; }
        public string? UserFullName { get; set; }
        public virtual ICollection<BookForView> OrderBook { get; set; }

        public static explicit operator Order(OrderForView forView)
        {
            var result = new Order
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator OrderForView(Order entity)
        {
            var result = new OrderForView
            {
                UserFullName = $"{entity?.User?.Name} {entity?.User?.Surname}",
                OrderBook = entity?.OrderBooks?.Select(x => (BookForView)x.Book).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
