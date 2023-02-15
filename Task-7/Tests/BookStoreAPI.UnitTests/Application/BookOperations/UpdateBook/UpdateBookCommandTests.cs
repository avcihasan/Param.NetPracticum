using AutoMapper;
using BookStoreAPI.API.Application.BookOperations.DeleteBook;
using BookStoreAPI.API.Application.BookOperations.UpdateBook;
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

namespace BookStoreAPI.UnitTests.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;


        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
       
        }


        [Fact]
        public void WhenGivenBookIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateBookCommand updateBookCommand = new(_context);
            updateBookCommand.BookId = 0;

            FluentActions.Invoking(() => updateBookCommand.Handle())
               .Should()
               .Throw<InvalidOperationException>()
               .And
               .Message
               .Should()
               .Be("Belirtilen Id'ye sahip kitap mevcut değildir.");
        }

        [Fact]
        public void WhenGivenBookIdIsinDB_InvalidOperationException_ShouldNotBeReturnError()
        {
            Book book=new Book() { Title="Test deneme",IsActive=true,PageCount=10, PublishDate=DateTime.Now.AddMinutes(-50),AuthorId=1,GenreId=1};
            _context.Books.Add(book);
            _context.SaveChanges();


            UpdateBookCommand updateBookCommand = new(_context);
            updateBookCommand.BookId = book.Id;
            updateBookCommand.Model = new() { GenreId=10,Title="test deneme 2"};

            FluentActions.Invoking(() => updateBookCommand.Handle()).Invoke();

            book.Title.Should().Be(updateBookCommand.Model.Title);
            book.GenreId.Should().Be(updateBookCommand.Model.GenreId);

        }
    }
}
