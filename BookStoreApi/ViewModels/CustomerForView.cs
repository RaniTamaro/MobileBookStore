using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreApi.ViewModels
{
    public class CustomerForView : BaseTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual ICollection<SelectListItem> OrdersNumber { get; set; }

        public static explicit operator Customer(CustomerForView forView)
        {
            var result = new Customer
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator CustomerForView(Customer entity)
        {
            var result = new CustomerForView
            {
                OrdersNumber = entity.Orders.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Number
                }).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
