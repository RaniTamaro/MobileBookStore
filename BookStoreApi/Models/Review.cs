using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class Review : BaseTable
    {
        public double Rating { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer? Customer { get; set; }
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book? Book { get; set; }
    }
}
