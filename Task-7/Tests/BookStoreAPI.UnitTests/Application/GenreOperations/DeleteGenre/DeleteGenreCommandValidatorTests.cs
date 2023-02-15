using BookStoreAPI.API.Application.BookOperations.DeleteBook;
using BookStoreAPI.API.Application.GenreOperations.DeleteGenre;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteGenreCommand deleteGenreCommand = new(null);
            deleteGenreCommand.GenreId = id;

            DeleteGenreCommandValidator validator = new();
            var result = validator.Validate(deleteGenreCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteGenreCommand deleteGenreCommand = new(null);
            deleteGenreCommand.GenreId = 1;

            DeleteGenreCommandValidator validator = new();
            var result = validator.Validate(deleteGenreCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
