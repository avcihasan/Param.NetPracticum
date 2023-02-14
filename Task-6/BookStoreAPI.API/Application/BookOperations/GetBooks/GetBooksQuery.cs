using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthors;
using BookStoreAPI.API.Application.GenreOperations.GetGenres;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.Application.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(x => x.Id).Where(x=>x.IsActive==true).ToList();
            return _mapper.Map<List<BookViewModel>>(bookList); 
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public GenreViewModel Genre { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}
