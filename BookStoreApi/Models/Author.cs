namespace BookStoreApi.Models
{
    public class Author : BaseTable
    {
        public string? Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
