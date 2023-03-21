using Library.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private LibraryDbContext _context;

        public IBookRepository Book { get; private set; }

        public ICartItemRepository CartItem { get; private set; }

        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
            Book = new BookRepository(context);
            CartItem = new CartItemRepository(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
