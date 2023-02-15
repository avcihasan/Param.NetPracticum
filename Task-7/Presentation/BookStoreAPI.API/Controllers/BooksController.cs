using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.Application.BookOperations.DeleteBook;
using BookStoreAPI.API.Application.BookOperations.GetBookById;
using BookStoreAPI.API.Application.BookOperations.GetBooks;
using BookStoreAPI.API.Application.BookOperations.UpdateBook;
using BookStoreAPI.API.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static BookStoreAPI.API.Application.BookOperations.CreateBook.CreateBookCommand;
using static BookStoreAPI.API.Application.BookOperations.GetBookById.GetBookByIdQuery;
using static BookStoreAPI.API.Application.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStoreAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreAPIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery getBooksQuery = new(_context, _mapper);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery getBookByIdQuery = new(_context, _mapper);
            getBookByIdQuery.BookId = id;
            GetBookByIdQueryValidator validator = new();
            validator.ValidateAndThrow(getBookByIdQuery);
            return Ok(getBookByIdQuery.Handle());

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand createBookCommand = new(_context, _mapper);
            createBookCommand.Model = newBook;
            CreateBookCommandValidator validator = new();
            validator.ValidateAndThrow(createBookCommand);
            createBookCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand updateBookCommand = new(_context);
            updateBookCommand.BookId = id;
            updateBookCommand.Model = updatedBook;
            UpdateBookCommandValidator validator = new();
            validator.ValidateAndThrow(updateBookCommand);
            updateBookCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new(_context);
            deleteBookCommand.BookId = id;
            DeleteBookCommandValidator validator = new();
            validator.ValidateAndThrow(deleteBookCommand);
            deleteBookCommand.Handle();
            return Ok();
        }
    }
}
