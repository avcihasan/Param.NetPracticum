using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieStore.Application.DTOs.MovieDTOs;
using MovieStore.Application.Repositories;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Extensions;

namespace MovieStore.Persistence.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<BaseUser> _usermanager;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IGenericRepository<Movie> repository, IMapper mapper, IMovieRepository movieRepository, ILogger<MovieService> logger, IOrderRepository orderRepository, UserManager<BaseUser> usermanager) : base(repository, logger)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _logger = logger;
            _orderRepository = orderRepository;
            _usermanager = usermanager;
        }

        public async Task BuyMovieAsync(int moiveId,string userName)
        {
            LoggerExtensions<MovieService>.MethodTriggered(_logger, "BuyMovieAsync");
            Movie movie=await _movieRepository.GetByIdAsync(moiveId);
           BaseUser cutomer=await _usermanager.FindByNameAsync(userName);
            Order order = new() {
                DateOfPurchase = DateTime.Now,
                MovieName = movie.Name,
                Price = movie.Price,
                CustomerId = cutomer.Id
            };
            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();
           
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
