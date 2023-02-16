using MovieStore.Domain.Entities;

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
    }
}
