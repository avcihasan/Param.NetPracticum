using MovieStore.Application.Services;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Services
{
    public interface IActorService:IService<Actor>
    {
        Task<GetActorDto> CreateActorAsync(CreateActorDto createActorDto);
        Task<GetActorDto> UpdateActorAsync(int actorId, UpdateActorDto updateActorDto);
        Task<List<GetActorDto>> GetAllActorsAsync();
    }
}
