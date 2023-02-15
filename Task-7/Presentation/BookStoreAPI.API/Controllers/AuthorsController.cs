using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.CreateAuthor;
using BookStoreAPI.API.Application.AuthorOperations.DeleteAuthor;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthorById;
using BookStoreAPI.API.Application.AuthorOperations.GetAuthors;
using BookStoreAPI.API.Application.AuthorOperations.UpdateAuthor;
using BookStoreAPI.API.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(BookStoreAPIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery getAuthorsQuery = new(_context, _mapper);
            return Ok(getAuthorsQuery.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetAuthorByIdQuery getAuthorByIdQuery = new(_context, _mapper);
            getAuthorByIdQuery.AuthorId = id;
            GetAuthorByIdQueryValidator validator = new();
            validator.ValidateAndThrow(getAuthorByIdQuery);
            return Ok(getAuthorByIdQuery.Handle());
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand createAuthorCommand = new(_context, _mapper);
            createAuthorCommand.Author = newAuthor;
            CreateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(createAuthorCommand);
            createAuthorCommand.Handle();
            return Ok();
        }


        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            DeleteAuthorCommand deleteAuthorCommand = new(_context);
            deleteAuthorCommand.AuthorId = authorId;
            DeleteAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(deleteAuthorCommand);
            deleteAuthorCommand.Handle();

            return Ok();
        }


        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor(int authorId, [FromBody] UpdateAuthorModel updateAuthorModel)
        {
            UpdateAuthorCommand updateAuthorCommand = new(_context);
            updateAuthorCommand.AuthorId = authorId;
            updateAuthorCommand.Author = updateAuthorModel;
            UpdateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(updateAuthorCommand);
            updateAuthorCommand.Handle();
            return Ok();
        }
    }
}
