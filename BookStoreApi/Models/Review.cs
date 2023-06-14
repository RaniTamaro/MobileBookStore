using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class Review : BaseTable
    {
        public double Rating { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User? User { get; set; }
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book? Book { get; set; }
    }
}
