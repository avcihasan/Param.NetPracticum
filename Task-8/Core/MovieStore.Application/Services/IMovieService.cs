using MovieStore.Application.Services;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Services
{
    public interface IMovieService:IService<Movie>
    {
        Task<GetMovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
        Task<GetMovieDto> UpdateMovieAsync(int movieId,UpdateMovieDto updateMovieDto);
        Task<List<GetMovieDto>> GetAllMoviesAsync();
        Task BuyMovieAsync(int moiveId,string userName);
    }
}
