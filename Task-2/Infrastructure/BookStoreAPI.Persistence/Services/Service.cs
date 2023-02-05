using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;



namespace BookStoreAPI.Persistence.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<CustomResponseDto<T>> AddAsync(T entity)
        {
             bool result= await _repository.AddAsync(entity);
            if (result)
            {
                await _repository.SaveAsync();
                return CustomResponseDto<T>.Success(201, entity);
            }
            return CustomResponseDto<T>.Fail(400, "Veri Eklenemedi");
        }

        public async Task<CustomResponseDto<List<T>>> GetAllAsync()
            => CustomResponseDto<List<T>>.Success(200, await _repository.GetAll().ToListAsync());

        public async Task<CustomResponseDto<T>> GetByIdAsync(int id)
        {
            T entity = await _repository.GetByIdAsync(id);
            if (entity==null)
                return CustomResponseDto<T>.Fail(404,"Bulunamadı");
            return CustomResponseDto<T>.Success(200, entity);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            T entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return CustomResponseDto<NoContentDto>.Fail(404, "Kayıtlı veri yok");

             bool result=_repository.Remove(entity);
            if (!result)
                return CustomResponseDto<NoContentDto>.Fail(400,"Silme Başarısız");
            await _repository.SaveAsync();
            return CustomResponseDto<NoContentDto>.Success(200);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(T entity)
        {
            bool result=_repository.Update(entity);
            if (!result)
                return CustomResponseDto<NoContentDto>.Fail(400, "Güncelleme Başarısız");
            await _repository.SaveAsync();
            return CustomResponseDto<NoContentDto>.Success(200);
        }
    }
}
