using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetAllBooksWithAllPropertiesAsync();
        Task<Book> GetBookByIdWithAllPropertiesAsync(int id);
        Task<Book> FilterByNameAsync(string name);
    }
}
