using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Models
{
    public class BookGenre : BaseTable
    {
        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }
        public int IdGenre { get; set; }
        [ForeignKey("IdGenre")]
        public virtual Genre Genre { get; set; }
    }
}
