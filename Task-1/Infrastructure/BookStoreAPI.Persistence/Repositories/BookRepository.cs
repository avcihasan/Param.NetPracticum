using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Domain.Entities;
using BookStoreAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreAPIDbContext context) : base(context)
        {}

        public IQueryable<Book> GetAllByPropertyNameToAscending(string propertyName)
            => _dbSet.AsQueryable().OrderBy(x => EF.Property<Object>(x,propertyName));

        public IQueryable<Book> GetAllByPropertyNameToDescending(string propertyName)
            =>  _dbSet.AsQueryable().OrderByDescending(x => EF.Property<Object>(x, propertyName));
    }
}
