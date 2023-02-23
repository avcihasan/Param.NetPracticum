using MovieStore.Domain.Entities;

namespace MovieStore.Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
    }
}
