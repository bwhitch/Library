using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }


        public async Task<List<Book>> LookupBooksAsync(string author, string title, int year)
        {
            return await Books
                .Where(b =>
                    b.Author == author ||
                    b.Title == title ||
                    (b.Year == year || year == 1))
                .OrderByDescending(b => b.Title)
                .ToListAsync();
        }
    }
}
