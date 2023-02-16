using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using MovieStore.Application.DTOs.ActorDTOs;
using MovieStore.Application.DTOs.DirectorDTOs;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
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
        public DirectorService(IGenericRepository<Director> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<GetDirectorDto> CreateDirectorAsync(CreateDirectorDto createDirectorDto)
        {
            Director director = _mapper.Map<Director>(createDirectorDto);
            return _mapper.Map<GetDirectorDto>(await AddAsync(director));
        }

        public async Task<List<GetDirectorDto>> GetAllDirectorsAsync()
            => _mapper.Map<List<GetDirectorDto>>(await GetAllAsync());
        public async Task<GetDirectorDto> UpdateDirectorAsync(int directorId, UpdateDirectorDto updateDirectorDto)
        {
            Director director = _mapper.Map<Director>(updateDirectorDto);
            director.Id = directorId;
            return _mapper.Map<GetDirectorDto>(await UpdateAsync(director));
        }
    }
}
