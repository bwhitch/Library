using Library.DataAccess.DTO;
using Library.Models;
using Library.Web.Models;

namespace Library.Web.ViewModels
{
    public class CartViewModel
    {

        public CartViewModel() 
        {        
        }

        public CartViewModel(IList<CartItemData> cartItemData)
        {
            NumberOfItems= cartItemData.Count;
            CartItemdData = cartItemData;
        }


        public int NumberOfItems { get; set; }

        public IList<CartItemData> CartItemdData { get; set; }

    }
}
