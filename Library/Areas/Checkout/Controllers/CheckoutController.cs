using Library.DataAccess.Repositories;
using Library.Models;
using Library.Web.Models;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Checkout.Controllers
{
    public class CheckoutController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CheckoutController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Checkout()
        {
            List<CartItemData> cart = HttpContext.Session.GetJson<List<CartItemData>>("Cart") ?? new List<CartItemData>();

            var model = new CheckoutViewModel(cart);
            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            //Check for member in database first.  If none return message and send back to checkout page.

            List<CartItemData> items = HttpContext.Session.GetJson<List<CartItemData>>("Cart");
            var books = items.ToList();

            foreach (var item in books)
            {
                var cartItem = new CartItem();
                cartItem.BookId = item.Book.Id;
                cartItem.MemberId = model.MemberId;
                cartItem.CheckoutDate = DateTime.Now;
                cartItem.Returned = false;
                _unitOfWork.CartItem.Add(cartItem);
                
            }
            _unitOfWork.SaveChanges();

            var cart = new List<CartItemData>();

            HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Receipt");
        }

        public IActionResult Receipt()
        {
            return View();
        }
    }
}
