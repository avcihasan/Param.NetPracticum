using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using MovieStore.Domain.Entities;

namespace BookStoreAPI.Persistence.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            bool result = await _repository.AddAsync(entity);
            if (result)
            {
                await _repository.SaveAsync();
                return entity;
            }
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
            => await _repository.GetAll().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("sagvs");
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            T entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("sagvs");

            bool result = _repository.Remove(entity);
            if (!result)
                throw new Exception("sagvs");
            await _repository.SaveAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            bool result = _repository.Update(entity);
            if (!result)
                throw new Exception("sagvs");

            await _repository.SaveAsync();
            return entity;
        }
    }
}
