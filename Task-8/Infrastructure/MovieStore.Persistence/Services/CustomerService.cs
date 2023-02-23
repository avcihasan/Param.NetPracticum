using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MovieStore.Application.DTOs.CustomerDTOs;
using MovieStore.Application.DTOs.TokenDTOs;
using MovieStore.Application.Repositories;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Extensions;

namespace MovieStore.Persistence.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        private readonly UserManager<BaseUser> _userManager;
        private readonly SignInManager<BaseUser> _signInManager;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IGenericRepository<Customer> repository, IMapper mapper, ILogger<CustomerService> logger, ITokenHandler tokenHandler, UserManager<BaseUser> userManager, SignInManager<BaseUser> signInManager) : base(repository, logger)
        {
            _mapper = mapper;
            _logger = logger;
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            LoggerExtensions<CustomerService>.MethodTriggered(_logger, "CreateCustomerAsync");
            Customer customer = _mapper.Map<Customer>(createCustomerDto);
            IdentityResult result = await _userManager.CreateAsync(customer, createCustomerDto.Password);
            if (!result.Succeeded)
                throw new Exception("Kayıt Hatası! ");
        }

        public async Task<TokenDto> LoginCustomerAsync(LoginCustomerDto loginCustomerDto)
        {
            LoggerExtensions<CustomerService>.MethodTriggered(_logger, "LoginCustomerAsync");
            await _repository.GetByIdAsync(1);
            BaseUser customer = await _userManager.FindByNameAsync(loginCustomerDto.Username);
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(customer, loginCustomerDto.Password, false) ;
            if (result.Succeeded)
            {
                return _tokenHandler.CreateAccessToken(5);
            }
            else
                throw new Exception("Hatalı Giriş");
        }
    }
}
