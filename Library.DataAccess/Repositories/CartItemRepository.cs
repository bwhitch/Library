using Library.DataAccess.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        private LibraryDbContext _context;

        public CartItemRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
