using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreAPIDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Author author = _dbContext.Authors.Include(x=>x.Books).SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı");
            foreach (Book book in author.Books)
                if (book.IsActive)
                    throw new InvalidOperationException("Yazarın aktif kitabı olduğu için yazar silinemez");

            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }

       
    }
}
