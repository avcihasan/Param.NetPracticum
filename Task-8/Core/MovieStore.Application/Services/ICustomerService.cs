using MovieStore.Application.Services;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Domain.Entities;
using MovieStore.Application.DTOs.TokenDTOs;

namespace MovieStore.Application.Services
{
    public interface ICustomerService:IService<Customer>
    {
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task<TokenDto> LoginCustomerAsync(LoginCustomerDto loginCustomerDto);

    }
}
