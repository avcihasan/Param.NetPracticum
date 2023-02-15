using AutoMapper;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Genre { get; set; }

        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            Genre genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Genre.Name);
            if (genre != null)
                throw new InvalidOperationException("Tür zaten mevcut.");
            genre = _mapper.Map<Genre>(Genre);

            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public class CreateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
        }
    }
}
