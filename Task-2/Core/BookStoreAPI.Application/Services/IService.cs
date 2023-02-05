using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Domain.Entities;

namespace BookStoreAPI.Application.Services
{
    public interface IService<T>  where T : BaseEntity
    {
        //metot imzaları
        Task<CustomResponseDto<T>> AddAsync(T entity);
        Task<CustomResponseDto<List<T>>> GetAllAsync();
        Task<CustomResponseDto<T>> GetByIdAsync(int id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(T entity);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id);
    }
}
