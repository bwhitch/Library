using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }
    
        public virtual Guid BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }

        public virtual int MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        public DateTime CheckoutDate { get; set; }

        public bool Returned { get; set; }

    }
}
