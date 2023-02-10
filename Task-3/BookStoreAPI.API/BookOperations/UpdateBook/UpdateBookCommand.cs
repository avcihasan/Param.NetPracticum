using BookStoreAPI.API.DBOperations;

namespace BookStoreAPI.API.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }

        public int BookId { get; set; }

        private readonly BookStoreAPIDbContext _dbContext;

        public UpdateBookCommand(BookStoreAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book==null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip kitap mevcut değildir.");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}

