using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IMapper _mapper;
        public CustomerService(IGenericRepository<Customer> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }



        public async Task<GetCustomerDto> CreateMovieAsync(CreateCustomerDto createCustomerDto)
        {
            Customer customer = _mapper.Map<Customer>(createCustomerDto);
            return _mapper.Map<GetCustomerDto>(await AddAsync(customer));
        }
    }
}
