using BookStoreAPI.Domain.Entities;

namespace BookStoreAPI.Application.Repositories
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        IQueryable<Book> GetAllByPropertyNameToAscending(string propertyName);
        IQueryable<Book> GetAllByPropertyNameToDescending(string propertyName);
    }
}
