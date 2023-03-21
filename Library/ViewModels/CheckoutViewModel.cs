using Library.Models;
using Library.Web.Models;

namespace Library.Web.ViewModels
{
    public class CheckoutViewModel
    {

        public CheckoutViewModel() 
        { 
        }

        public CheckoutViewModel(IList<CartItemData> items) 
        { 
            TotalBooks= items.Count;
            Items = items;
        }
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TotalBooks { get; set; }

        public IList<CartItemData> Items { get; set; }
    }
}
