using MovieStore.Application.Services;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.DirectorDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Services
{
    public interface IDirectorService:IService<Director>
    {
        Task<GetDirectorDto> CreateDirectorAsync(CreateDirectorDto createDirectorDto);
        Task<GetDirectorDto> UpdateDirectorAsync(int directorId, UpdateDirectorDto updateDirectorDto);
        Task<List<GetDirectorDto>> GetAllDirectorsAsync();
    }
}
