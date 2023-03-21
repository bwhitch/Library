using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Web.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Book Title")]
        public string Title { get; set; } = "Title";

        [Display(Name = "Author")]
        public string Author { get; set; } = "Author";

        [Display(Name = "Year")]
        public int Year { get; set; } = 1;
    }
}
