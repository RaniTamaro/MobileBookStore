namespace BookStoreApi.Models
{
    public class Employee : BaseTable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<OrderEmployee> OrderEmployees { get; set; }
    }
}
