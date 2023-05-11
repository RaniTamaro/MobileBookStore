using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class OrderBook : BaseTable
    {
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; } 
    }
}
