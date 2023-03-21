using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Web.ViewModels
{
    public class SearchResultViewModel
    {
        public SearchResultViewModel(IList<Book> books, int totalRecords)
        {
            this.Books = books;
            this.TotalRecords = totalRecords;
        }
        public IList<Book> Books { get; set; }

        public int TotalRecords { get; set; } = 0;
    }
}
