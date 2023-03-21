using Library.DataAccess.Data;
using Library.DataAccess.Repositories;
using Library.Models;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Areas.Catalog.Controllers
{
    public class CatalogController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CatalogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _unitOfWork.Book.GetAll();

            return View(books);
        }

        public IActionResult Search()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken] //key is injected on view. avoids cross site request forgery
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            //TODO.  Move this to the repository and make a call through the the unti of work.
            var searchResult = _unitOfWork.Book.LookupBooks(model.Author, model.Title, model.Year);
            var searchResultViewModel = new SearchResultViewModel(searchResult.Books, searchResult.TotalRecords);

            return View("SearchResult", searchResultViewModel);
        }


        public IActionResult Detail(Guid id)
        {
            var detail = _unitOfWork.Book.Get(id);
            return View(detail);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            //TODO:  Create admin view/model to allow staff to add books into catalog
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Add(book);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
