using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.DBOperations
{
    public class BookStoreAPIDbContext:DbContext
    {
        public BookStoreAPIDbContext(DbContextOptions<BookStoreAPIDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
    }
}
