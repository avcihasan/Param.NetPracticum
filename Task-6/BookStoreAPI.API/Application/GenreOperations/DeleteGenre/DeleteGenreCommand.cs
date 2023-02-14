using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly BookStoreAPIDbContext _dbContext;

        public DeleteGenreCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Genre genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
                throw new InvalidOperationException("Silinecek tür bulunamadı");
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();

        }
    }
}
