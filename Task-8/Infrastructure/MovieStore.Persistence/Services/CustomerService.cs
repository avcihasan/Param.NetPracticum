using AutoMapper;
using Azure.Core;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Extensions;
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
        private readonly ILogger<CustomerService> _logger;
        private readonly UserManager<BaseUser> _userManager;
        private readonly SignInManager<BaseUser> _signInManager;
        public CustomerService(IGenericRepository<Customer> repository, IMapper mapper, ILogger<CustomerService> logger, UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager) : base(repository, logger)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<GetCustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            LoggerExtensions<CustomerService>.MethodTriggered(_logger, "CreateCustomerAsync");
            Customer customer = _mapper.Map<Customer>(createCustomerDto);

            return _mapper.Map<GetCustomerDto>(await AddAsync(customer));
        }

        public async Task LoginCustomerAsync(LoginCustomerDto loginCustomerDto)
        {
            BaseUser user = await _userManager.FindByNameAsync(loginCustomerDto.UserName);
            if (user == null)
                throw new Exception("Girilen Bilgileri Kontrol Ediniz");
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginCustomerDto.Password, false);
            if (result.Succeeded)
            {
                //TokenDto token = _tokenHandler.CreateAccessToken(5);
                //return new LoginUserSuccessCommandResponse() { Token = token };
            }

            throw new Exception("Hatalı Giriş");
        }
    }
}
