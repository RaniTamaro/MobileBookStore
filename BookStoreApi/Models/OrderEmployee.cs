using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class OrderEmployee : BaseTable
    {
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public virtual Employee Employee { get; set; }
    }
}
