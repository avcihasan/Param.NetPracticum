using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthors;
using BookStoreAPI.API.Application.GenreOperations.GetGenres;
using BookStoreAPI.API.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.Application.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBookByIdQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookViewIdModel Handle()
        {  
            var book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(book => book.Id == BookId).SingleOrDefault();
            if (book == null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip kitap mevcut değildir.");
            else if(!book.IsActive)
                throw new InvalidOperationException("Belirtilen Id'ye sahip kitap aktif değildir.");

            return _mapper.Map<BookViewIdModel>(book);
        }

        public class BookViewIdModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public GenreViewModel Genre { get; set; }
            public AuthorViewModel Author { get; set; }
        };
    }
}
