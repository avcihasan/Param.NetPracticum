
using MovieStore.Domain.Entities;

namespace BookStoreAPI.Application.Services
{
    public interface IService<T>  where T : class
    {
        //metot imzaları
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(int id);
    }
}
