using AutoMapper;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.GenreOperations.GetGenreById
{
    public class GetGenreByIdQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenreByIdQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreViewIdModel Handle()
        {
            Genre genre = _dbContext.Genres.Where(book => book.Id == GenreId).SingleOrDefault();
            if (genre == null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip tür mevcut değildir.");
            return _mapper.Map<GenreViewIdModel>(genre);
        }

        public class GenreViewIdModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        };
    }
}