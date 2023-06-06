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
        public int IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderBook> OrderBooks { get; set; }
    }
}
