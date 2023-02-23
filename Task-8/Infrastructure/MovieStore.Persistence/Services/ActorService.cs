using AutoMapper;
using MovieStore.Application.Repositories;
using MovieStore.Persistence.Services;
using Microsoft.Extensions.Logging;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Extensions;

namespace MovieStore.Persistence.Services
{
    public class ActorService : Service<Actor>, IActorService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ActorService> _logger;
        public ActorService(IGenericRepository<Actor> repository, IMapper mapper, ILogger<ActorService> logger) : base(repository, logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetActorDto> CreateActorAsync(CreateActorDto createActorDto)
        {
            LoggerExtensions<ActorService>.MethodTriggered(_logger, "CreateActorAsync");
            Actor actor = _mapper.Map<Actor>(createActorDto);
            return _mapper.Map<GetActorDto>(await AddAsync(actor));
        }

        public async Task<List<GetActorDto>> GetAllActorsAsync()
        {
            LoggerExtensions<ActorService>.MethodTriggered(_logger, "GetAllActorsAsync");
            return _mapper.Map<List<GetActorDto>>(await GetAllAsync());

        }

        public async Task<GetActorDto> UpdateActorAsync(int actorId, UpdateActorDto updateActorDto)
        {
            LoggerExtensions<ActorService>.MethodTriggered(_logger, "UpdateActorAsync");
            Actor actor = await GetByIdAsync(actorId);
            if (actor == null)
                throw new InvalidOperationException("Actor Kayıtlı Değil!");
           
            actor = _mapper.Map<Actor>(updateActorDto);
            actor.Id = actorId;
            return _mapper.Map<GetActorDto>(await UpdateAsync(actor));
        }
    }
}
