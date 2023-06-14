using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class Order : BaseTable
    {
        public string Number { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public string Address { get; set; }
        public string? Status { get; set; }
        public string? TrackingNumber { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User? User { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
