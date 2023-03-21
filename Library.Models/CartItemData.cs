using Library.Models;

namespace Library.Web.Models
{
    public class CartItemData
    {
        public Guid Id { get; set; }

        public Book Book { get; set; }
    }
}
