namespace BookStoreApi.Models
{
    public class Genre : BaseTable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
