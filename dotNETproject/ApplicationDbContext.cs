using dotNETproject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dotNETproject
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }

}
