using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using Microsoft.Extensions.Logging;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.DirectorDTOs;
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
    internal class DirectorService : Service<Director>, IDirectorService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DirectorService> _logger;
        public DirectorService(IGenericRepository<Director> repository, IMapper mapper, ILogger<DirectorService> logger) : base(repository,logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetDirectorDto> CreateDirectorAsync(CreateDirectorDto createDirectorDto)
        {
            LoggerExtensions<DirectorService>.MethodTriggered(_logger, "CreateDirectorAsync");
            Director director = _mapper.Map<Director>(createDirectorDto);
            return _mapper.Map<GetDirectorDto>(await AddAsync(director));
        }

        public async Task<List<GetDirectorDto>> GetAllDirectorsAsync()
        {
            LoggerExtensions<DirectorService>.MethodTriggered(_logger, "GetAllDirectorsAsync");
            return _mapper.Map<List<GetDirectorDto>>(await GetAllAsync());
        }
            
        public async Task<GetDirectorDto> UpdateDirectorAsync(int directorId, UpdateDirectorDto updateDirectorDto)
        {
            LoggerExtensions<DirectorService>.MethodTriggered(_logger, "UpdateDirectorAsync");
            Director director = _mapper.Map<Director>(updateDirectorDto);
            director.Id = directorId;
            return _mapper.Map<GetDirectorDto>(await UpdateAsync(director));
        }
    }
}
