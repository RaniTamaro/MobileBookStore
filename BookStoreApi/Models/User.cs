namespace BookStoreApi.Models
{
    public class User : BaseTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
