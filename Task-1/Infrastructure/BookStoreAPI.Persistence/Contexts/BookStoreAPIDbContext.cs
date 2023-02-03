using BookStoreAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Persistence.Contexts
{
    public class BookStoreAPIDbContext:DbContext 
    {
        public BookStoreAPIDbContext(DbContextOptions options):base(options)
        {}
        public DbSet<Book> Books { get; set; }
    }
}
