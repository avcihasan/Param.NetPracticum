using BookStoreAPI.API.Application.BookOperations.CreateBook;
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
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Deneme", 0, 0, 0)]
        [InlineData("Deneme", 0, 0, 1)]
        [InlineData("Deneme", 0, 1, 0)]
        [InlineData("Deneme", 1, 0, 0)]
        [InlineData("Deneme", 0, 1, 1)]
        [InlineData("Deneme", 1, 0, 1)]
        [InlineData("Deneme", 1, 1, 0)]
        [InlineData("", 0, 0, 1)]
        [InlineData("", 0, 1, 1)]
        [InlineData("", 1, 1, 1)]
        [InlineData("", 1, 0, 1)]
        [InlineData("", 1, 0, 0)]
        [InlineData("", 1, 1, 0)]
        [InlineData("", 0, 1, 0)]
        [InlineData("", 0, 0, 0)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
            CreateBookCommand createBookCommand = new(null, null);
            createBookCommand.Model = new()
            {
                PublishDate = DateTime.Now.AddDays(-10),
                AuthorId = authorId,
                GenreId = genreId,
                PageCount = pageCount,
                Title = title

            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {

            CreateBookCommand createBookCommand = new(null, null);
            createBookCommand.Model = new()
            {
                PublishDate = DateTime.Now.Date,
                AuthorId = 1,
                GenreId = 1,
                PageCount = 1,
                Title = "deneme"

            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {

            CreateBookCommand createBookCommand = new(null, null);
            createBookCommand.Model = new()
            {
                PublishDate = DateTime.Now.Date.AddYears(-50),
                AuthorId = 1,
                GenreId = 1,
                PageCount = 1,
                Title = "TestDeneme"

            };
            CreateBookCommandValidator validator = new();
            var result = validator.Validate(createBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
