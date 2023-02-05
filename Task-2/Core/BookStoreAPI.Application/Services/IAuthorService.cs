using BookStoreAPI.Application.DTOs.BookDTOs;
using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Application.DTOs.AuthorDTOs;

namespace BookStoreAPI.Application.Services
{
    public interface IAuthorService:IService<Author>
    {
        Task<CustomResponseDto<GetAuthorDto>> AddAuthorAsync(SetAuthorDto setAuthorDto); 

        Task<CustomResponseDto<GetAuthorDto>> UpdateAuthorAsync(int id,SetAuthorDto setAuthorDto); 
    }
}
