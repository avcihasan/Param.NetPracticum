using AutoMapper;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<GenreViewModel> Handle()
        {
            List<Genre> genres = _dbContext.Genres.OrderBy(x => x.Id).ToList();
            return _mapper.Map<List<GenreViewModel>>(genres);
        }
    }

    public class GenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
