using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
        IQueryable<T> GetAllByPropertyNameToAscending(string propertyName);
        IQueryable<T> GetAllByPropertyNameToDescending(string propertyName);
    }
}
