using AutoMapper;
using BookStoreAPI.API.DBOperations;

namespace BookStoreAPI.API.BookOperations.GetBookByIdQuery
{
    public class GetBooksByIdQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }

        public GetBooksByIdQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BooksViewIdModel Handle(int id)
        {
            var book = _dbContext.Books.Where(book => book.Id == id).SingleOrDefault();
            if (book==null)
                throw new InvalidOperationException("Belirtilen Id'ye sahip kitap mevcut değildir.");
            return _mapper.Map<BooksViewIdModel>(book);
        }

        public class BooksViewIdModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        };
    }
}
