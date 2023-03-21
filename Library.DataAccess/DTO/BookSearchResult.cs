using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.DTO
{
    public class BookSearchResult
    {
        public IList<Book> Books { get; set; }

        public int TotalRecords { get; set; } = 0;
    }
}
