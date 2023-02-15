using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.GetBooks;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            List<Author> authors = _dbContext.Authors.OrderBy(x => x.Id).ToList();
            return _mapper.Map<List<AuthorViewModel>>(authors); 

        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}

