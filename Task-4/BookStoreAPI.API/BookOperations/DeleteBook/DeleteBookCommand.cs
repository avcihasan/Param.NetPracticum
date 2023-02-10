using BookStoreAPI.API.DBOperations;

namespace BookStoreAPI.API.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreAPIDbContext _dbContext;

        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book == null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }

    }
}
