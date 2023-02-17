using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Extensions;
using MovieStore.Persistence.Services;
using System.Net;

namespace BookStoreAPI.Persistence.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        private readonly ILogger<Service<T>> _logger;

        public Service(IGenericRepository<T> repository, ILogger<Service<T>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<T> AddAsync(T entity)
        {
            LoggerExtensions<Service<T>>.MethodTriggered(_logger, "AddAsync");
            bool result = await _repository.AddAsync(entity);
            if (!result)
                throw new Exception($"{typeof(T).Name} Ekleme Hatası!");
            await _repository.SaveAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            LoggerExtensions<Service<T>>.MethodTriggered(_logger, "GetAllAsync");
            return await _repository.GetAll().ToListAsync();
        }
            

        public async Task<T> GetByIdAsync(int id)
        {
            LoggerExtensions<Service<T>>.MethodTriggered(_logger, "GetByIdAsync");
            T entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} veritabanında kayıtlı değil!");
            return entity;
        }

        public async Task RemoveAsync(int id)
        {
            LoggerExtensions<Service<T>>.MethodTriggered(_logger, "RemoveAsync");
            T entity = await GetByIdAsync(id); 

            bool result = _repository.Remove(entity);
            if (!result)
                throw new Exception($"{typeof(T).Name} Silme Hatası!");
            await _repository.SaveAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            LoggerExtensions<Service<T>>.MethodTriggered(_logger, "UpdateAsync");
            bool result = _repository.Update(entity);
            if (!result)
                throw new Exception($"{typeof(T).Name} Güncelleme Hatası!");
            await _repository.SaveAsync();
            return entity;
        }
    }
}
