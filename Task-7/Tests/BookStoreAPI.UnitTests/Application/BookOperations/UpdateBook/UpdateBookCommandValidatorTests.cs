using BookStoreAPI.API.Application.BookOperations.DeleteBook;
using BookStoreAPI.API.Application.BookOperations.UpdateBook;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("deneme",0,0)]
        [InlineData("deneme",0,1)]
        [InlineData("deneme",1,0)]
        [InlineData("",1,0)]
        [InlineData("",1,1)]
        [InlineData("",0,1)]
        public void xxx(string title,int bookId,int genreId)
        {
            UpdateBookCommand updateBookCommand = new(null);
            updateBookCommand.BookId = bookId;
            updateBookCommand.Model = new() { GenreId=genreId,Title=title};

            UpdateBookCommandValidator validator = new();
            var result = validator.Validate(updateBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void yyyy()
        {
            UpdateBookCommand updateBookCommand = new(null);
            updateBookCommand.BookId = 1;
            updateBookCommand.Model = new() { GenreId = 1, Title = "denemee" };

            UpdateBookCommandValidator validator = new();
            var result = validator.Validate(updateBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
