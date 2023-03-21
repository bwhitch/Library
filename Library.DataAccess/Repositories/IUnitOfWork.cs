using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }

        ICartItemRepository CartItem { get; }

        void SaveChanges();
    }
}
