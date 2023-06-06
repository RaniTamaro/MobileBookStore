using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class BaseTable
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? CretionDate { get; set; } = DateTime.Now;
        public DateTime? MmodifDate { get; set; } = DateTime.Now;
    }
}
