using Library.DataAccess.Data;
using Library.DataAccess.DTO;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private LibraryDbContext _context;

        public BookRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public BookSearchResult LookupBooks(string author, string title, int year)
        {
            var books =  (from cls in GetAll()
                    where cls.Author.Contains(author)
                    || cls.Title.Contains(title)
                    || (cls.Year == year)
                    select cls).ToList();

            return new BookSearchResult
            {
                Books = books,
                TotalRecords = books.Count
            };
        }
    }
}
