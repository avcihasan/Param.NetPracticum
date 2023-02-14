using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel Genre { get; set; }

        public int GenreId { get; set; }

        private readonly BookStoreAPIDbContext _dbContext;

        public UpdateGenreCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Genre genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip tür mevcut değildir.");

            genre.Name = Genre.Name != default ? Genre.Name : genre.Name;
            genre.IsActive = Genre.IsActive != default ? Genre.IsActive : genre.IsActive;
            _dbContext.SaveChanges();
        }

        public class UpdateGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}

