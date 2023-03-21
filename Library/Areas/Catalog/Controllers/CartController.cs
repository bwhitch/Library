using Library.DataAccess.Repositories;
using Library.Models;
using Library.Web.Models;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Catalog.Controllers
{
    public class CartController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private IUnitOfWork _unitOfWork;

        public CartController(IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CartItemData> cart = HttpContext.Session.GetJson<List<CartItemData>>("Cart") ?? new List<CartItemData>();

            var model = new CartViewModel(cart);

            return View(model);
        }

        public async Task<IActionResult> AddToCart(Guid id)
        {
            Book book = await _unitOfWork.Book.GetAsync(id);

            var testCart = HttpContext.Session.GetJson<List<CartItemData>>("Cart");


            List<CartItemData> cart = HttpContext.Session.GetJson<List<CartItemData>>("Cart") ?? new List<CartItemData>();

            var cartItem = new CartItemData
            {
                Book = book
            };

            if(cart.Count < 5)
            {
                cart.Add(cartItem);
                TempData["Success"] = cartItem.Book.Title + " was added to your cart";
            }
            else
            {
                TempData["ItemError"] = "Cannot checkout more than 5 items at a time.  Remove items in order to add more.";
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid id) 
        {
            List<CartItemData> cart = HttpContext.Session.GetJson<List<CartItemData>>("Cart");

            CartItemData item = cart.FirstOrDefault(c => c.Book.Id == id);

            cart.Remove(item);

            HttpContext.Session.SetJson("Cart", cart);

            return RedirectToAction("Index");
        }
    }
}
