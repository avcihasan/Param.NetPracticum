using BookStoreAPI.Application.Services;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Services
{
    public interface ICustomerService:IService<Customer>
    {
        Task<GetCustomerDto> CreateMovieAsync(CreateCustomerDto createCustomerDto);
    }
}
