using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.UserDTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Services
{
    public interface IUserService:IService<User>
    {
        Task<CustomResponseDto<NoContentDto>> LoginAsync (LoginUserDto loginUserDto);
        Task<CustomResponseDto<NoContentDto>> AddUserAsync (SetUserDto setUserDto);
    }
}
