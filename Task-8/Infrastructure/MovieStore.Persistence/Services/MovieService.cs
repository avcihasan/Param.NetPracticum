using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Application.Repositories;
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
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IGenericRepository<Movie> repository, IMapper mapper, IMovieRepository movieRepository, ILogger<MovieService> logger) : base(repository, logger)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _logger = logger;
        }

        public async Task<GetMovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
        {
            LoggerExtensions<MovieService>.MethodTriggered(_logger, "CreateMovieAsync");

            Movie movie = _mapper.Map<Movie>(createMovieDto);
            return _mapper.Map<GetMovieDto>(await AddAsync(movie));
        }

        public async Task<List<GetMovieDto>> GetAllMoviesAsync()
        {
            LoggerExtensions<MovieService>.MethodTriggered(_logger, "GetAllMoviesAsync");

            return _mapper.Map<List<GetMovieDto>>(await _movieRepository.GetAllMoviesWithAllProperties().ToListAsync());
        }


        public async Task<GetMovieDto> UpdateMovieAsync(int movieId, UpdateMovieDto updateMovieDto)
        {
            LoggerExtensions<MovieService>.MethodTriggered(_logger, "UpdateMovieAsync");
            Movie movie = _mapper.Map<Movie>(updateMovieDto);
            movie.Id = movieId;
            return _mapper.Map<GetMovieDto>(await UpdateAsync(movie));
        }
    }
}
