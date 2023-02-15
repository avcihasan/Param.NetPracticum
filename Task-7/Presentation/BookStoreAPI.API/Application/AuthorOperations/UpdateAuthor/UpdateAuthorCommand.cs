using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Author { get; set; }
        public int AuthorId { get; set; }
        private readonly BookStoreAPIDbContext _dbContext;

        public UpdateAuthorCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            Author author = _dbContext.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author==null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip yazar mevcut değildir.");

            author.Name = Author.Name != default ? Author.Name : author.Name;
            author.Surname = Author.Surname != default ? Author.Surname : author.Surname;
            author.Birthday = Author.Birthday != default ? Author.Birthday : author.Birthday;
            _dbContext.SaveChanges();

        }
    }

    public class UpdateAuthorModel
    {
        public string  Name { get; set; }
        public string  Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
