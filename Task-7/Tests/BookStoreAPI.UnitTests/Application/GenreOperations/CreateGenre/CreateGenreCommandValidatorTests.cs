using BookStoreAPI.API.Application.BookOperations.CreateBook;
using BookStoreAPI.API.Application.GenreOperations.CreateGenre;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aa")]
        [InlineData("aaa")]
        public void xxx(string name)
        {
            CreateGenreCommand createGenreCommand = new(null, null);
            createGenreCommand.Genre = new()
            {
                IsActive=true,
                Name = name
            };
            CreateGenreCommandValidator validator = new();
            var result = validator.Validate(createGenreCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]   
        public void yyy()
        {
            CreateGenreCommand createGenreCommand = new(null, null);
            createGenreCommand.Genre = new()
            {
                IsActive = true,
                Name = "test deneme"
            };
            CreateGenreCommandValidator validator = new();
            var result = validator.Validate(createGenreCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
