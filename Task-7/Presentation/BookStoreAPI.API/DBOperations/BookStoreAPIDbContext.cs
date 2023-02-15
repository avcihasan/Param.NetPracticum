using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.DBOperations
{
    public class BookStoreAPIDbContext:DbContext, IBookStoreAPIDbContext
    {
        public BookStoreAPIDbContext(DbContextOptions<BookStoreAPIDbContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Genre> Genres{ get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
