using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.GetBooks;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.Application.AuthorOperations.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }

        public GetAuthorByIdQuery(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorViewIdModel Handle()
        {
            Author author = _dbContext.Authors.Include(x=>x.Books).FirstOrDefault(x => x.Id == AuthorId);
            
            if (author == null)
                throw new InvalidOperationException("Böyle bir yazar kayıtlı değil");
            return _mapper.Map<AuthorViewIdModel>(author);


        }

    }
    public class AuthorViewIdModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public List<BookViewModel> Books { get; set; }

    };
}
