using System.ComponentModel.DataAnnotations.Schema;

namespace LisbrarySystem.Models
{
    public class Buy
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
    }
}
