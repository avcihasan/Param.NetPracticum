using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.Application.BookOperations.DeleteBook;
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

namespace BookStoreAPI.UnitTests.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyNotFoundBook_InvalidOperationException_ShouldBeReturn()
        {

            DeleteBookCommand deleteBookCommand = new(_context);
            deleteBookCommand.BookId = 0;

            FluentActions.Invoking(() => deleteBookCommand.Handle())
               .Should()
               .Throw<InvalidOperationException>()
               .And
               .Message
               .Should()
               .Be("Silinecek kitap bulunamadı");
        }


        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            Book book = new() { Title = "Test deneme", GenreId = 1, AuthorId = 1, IsActive = true, PageCount = 100, PublishDate = DateTime.Now.AddMinutes(-50) };
            _context.Books.Add(book);
            _context.SaveChanges();

            DeleteBookCommand deleteBookCommand = new(_context);
            deleteBookCommand.BookId = book.Id;



            FluentActions.Invoking(() => deleteBookCommand.Handle()).Invoke();


            book = _context.Books.FirstOrDefault(x => x.Id==book.Id);

            book.Should().BeNull();
           

        }
    }
}
