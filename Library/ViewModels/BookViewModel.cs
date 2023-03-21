using Library.Models;

namespace Library.Web.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {

        }
        public BookViewModel(Book book) 
        { 
            Id = book.Id;
            Title = book.Title;
            Author= book.Author;
            Rating= book.Rating;
            Reviews= book.Reviews;
            Price= book.Price;
            Year= book.Year;
            Genre = book.Genre.GenreType;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal? Rating { get; set; }

        public int? Reviews { get; set; }

        public decimal? Price { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

    }
}
