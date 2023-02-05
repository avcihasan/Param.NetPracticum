using BookStoreAPI.Application.DTOs;
using BookStoreAPI.Application.DTOs.GenreDTOs;
using BookStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Application.Services
{
    public interface IGenreService:IService<Genre>
    {
        Task<CustomResponseDto<GetGenreDto>> AddGenreAsync(SetGenreDto setGenreDto);

        Task<CustomResponseDto<GetGenreDto>> UpdateGenreAsync(int id, SetGenreDto setGenreDto);
    }
}
