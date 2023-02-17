using BookStoreAPI.Application.Services;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Domain.Entities;

namespace MovieStore.Application.Services
{
    public interface ICustomerService:IService<Customer>
    {
        Task<GetCustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task LoginCustomerAsync(LoginCustomerDto loginCustomerDto);

    }
}
