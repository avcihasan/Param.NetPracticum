using AutoMapper;
using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.DTOs.UserDTOs;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Domain.Entities;
using BookStoreAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Persistence.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IGenericRepository<User> repository, IMapper mapper, ILogger<UserService> logger) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<CustomResponseDto<NoContentDto>> AddUserAsync(SetUserDto setUserDto)
        {
            _logger.LogInformation("AddUserAsync tetiklendi");//loglama
            User user = _mapper.Map<User>(setUserDto);
            bool result=await _repository.AddAsync(user);
            if (!result)
                return CustomResponseDto<NoContentDto>.Fail(400, "Kullanıcı Eklenemedi");
            await _repository.SaveAsync();

            return CustomResponseDto<NoContentDto>.Success(201);
        }

        public async Task<CustomResponseDto<NoContentDto>> LoginAsync(LoginUserDto loginUserDto)
        {
            _logger.LogInformation("LoginAsync tetiklendi");//loglama
            List<User> users= await _repository.GetAll().ToListAsync();
            foreach (User user in users)
            {
                if (user.Email==loginUserDto.Email && user.Password==loginUserDto.Password)
                    return CustomResponseDto<NoContentDto>.Success(201);
            }
            return CustomResponseDto<NoContentDto>.Fail(400,"Giriş Hatası");
        }
    }
}
