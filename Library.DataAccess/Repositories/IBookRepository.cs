using Library.DataAccess.DTO;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        BookSearchResult LookupBooks(string author, string title, int year);
    }
}
