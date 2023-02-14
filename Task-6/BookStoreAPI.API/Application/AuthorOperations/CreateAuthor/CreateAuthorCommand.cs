using AutoMapper;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;

namespace BookStoreAPI.API.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Author { get; set; }

        private readonly BookStoreAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Author author= _dbContext.Authors.SingleOrDefault(x => x.Name.ToLower() == Author.Name.ToLower() && x.Surname.ToLower() == Author.Surname.ToLower());
            if (author != null)
                throw new InvalidOperationException("Yazar zaten mevcut.");
            author = _mapper.Map<Author>(Author);

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
     

    }
}
