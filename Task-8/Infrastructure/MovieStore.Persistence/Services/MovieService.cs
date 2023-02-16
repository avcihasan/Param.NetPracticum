using AutoMapper;
using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Services;
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
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movie> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<GetMovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
        {
            Movie movie = _mapper.Map<Movie>(createMovieDto);
            return _mapper.Map<GetMovieDto>(await AddAsync(movie));
        }

        public async Task<List<GetMovieDto>> GetAllMoviesAsync()
            => _mapper.Map<List<GetMovieDto>>(await GetAllAsync());
       

        public async Task<GetMovieDto> UpdateMovieAsync(int movieId, UpdateMovieDto updateMovieDto)
        {
            Movie movie = _mapper.Map<Movie>(updateMovieDto);
            movie.Id = movieId;
            return _mapper.Map<GetMovieDto>(await UpdateAsync(movie));
        }
    }
}
