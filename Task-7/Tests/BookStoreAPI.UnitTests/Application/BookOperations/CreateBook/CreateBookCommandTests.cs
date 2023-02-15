using AutoMapper;
using BookStoreAPI.API.Application.AuthorOperations.CreateAuthor;
using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.BookOperations.CreateBook
{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            Book book = new() { Title = "Deneme Test", AuthorId = 1, GenreId = 1, IsActive = true,PageCount=10,PublishDate=DateTime.Now.AddDays(-50) };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand createBookCommand = new(_context,_mapper);
            createBookCommand.Model = new() { Title = book.Title, GenreId=book.GenreId,PageCount=book.PageCount,PublishDate=book.PublishDate,AuthorId=book.AuthorId};


            FluentActions.Invoking(() => createBookCommand.Handle())
                .Should()
                .Throw<InvalidOperationException>()
                .And
                .Message
                .Should()
                .Be("Kitap zaten mevcut.");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            

            CreateBookCommand createBookCommand = new(_context, _mapper);
            createBookCommand.Model = new() { Title = "TestDeneme", AuthorId = 1, GenreId = 1,PageCount = 200, PublishDate = DateTime.Now.AddMonths(-4) };


            FluentActions.Invoking(() => createBookCommand.Handle()).Invoke();


            Book book = _context.Books.FirstOrDefault(x=>x.Title== createBookCommand.Model.Title);

            book.Should().NotBeNull();
            book.PageCount.Should().Be(createBookCommand.Model.PageCount);
            book.PublishDate.Should().Be(createBookCommand.Model.PublishDate);
            book.GenreId.Should().Be(createBookCommand.Model.GenreId);
            book.AuthorId.Should().Be(createBookCommand.Model.AuthorId);

        }
    }
}
