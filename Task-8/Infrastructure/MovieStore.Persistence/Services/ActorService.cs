using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Services
{
    internal class ActorService : Service<Actor>, IActorService
    {
        private readonly IMapper _mapper;
        public ActorService(IGenericRepository<Actor> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<GetActorDto> CreateActorAsync(CreateActorDto createActorDto)
        {
            Actor actor = _mapper.Map<Actor>(createActorDto);
            return _mapper.Map<GetActorDto>(await AddAsync(actor));
        }

        public async Task<List<GetActorDto>> GetAllActorsAsync()
             => _mapper.Map<List<GetActorDto>>(await GetAllAsync());

        public async Task<GetActorDto> UpdateActorAsync(int actorId, UpdateActorDto updateActorDto)
        {
            Actor actor = _mapper.Map<Actor>(updateActorDto);
            actor.Id = actorId;
            return _mapper.Map<GetActorDto>(await UpdateAsync(actor));
        }
    }
}
