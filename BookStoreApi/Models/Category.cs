namespace BookStoreApi.Models
{
    public class Category : BaseTable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
