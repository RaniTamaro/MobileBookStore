using BookStoreApi.Models;
using BookStoreApi.ViewModels.Helpers;

namespace BookStoreApi.ViewModels
{
    public class UserForView : BaseTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<OrderForView>? Orders { get; set; }

        public static explicit operator User(UserForView forView)
        {
            var result = new User
            {
            }
            .CopyProperties(forView);
            return result;
        }
        public static implicit operator UserForView(User entity)
        {
            var result = new UserForView
            {
                Orders = entity.Orders?.Select(x => (OrderForView)x).ToList()
            }
            .CopyProperties(entity);
            return result;
        }
    }
}
