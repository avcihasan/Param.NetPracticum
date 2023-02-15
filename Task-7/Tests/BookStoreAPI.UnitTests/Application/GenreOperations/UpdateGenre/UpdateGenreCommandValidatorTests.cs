using BookStoreAPI.API.Application.BookOperations.UpdateBook;
using BookStoreAPI.API.Application.GenreOperations.UpdateGenre;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("",-1)]
        [InlineData("d",-1)]
        [InlineData("dd",-1)]
        [InlineData("ddd",-1)]
        [InlineData("dddd",-1)]
        [InlineData("d",10)]
        [InlineData("dd",10)]
        [InlineData("ddd",10)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(string name,int id)
        {
            UpdateGenreCommand updateGenreCommand = new(null);
            updateGenreCommand.GenreId = id;
            updateGenreCommand.Genre = new() { IsActive = true, Name = name };


            UpdateGenreCommandValidator validator = new();
            var result = validator.Validate(updateGenreCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Theory]
        [InlineData("", 10)]
        [InlineData("ddddd", 10)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(string name, int id)
        {
            UpdateGenreCommand updateGenreCommand = new(null);
            updateGenreCommand.GenreId = id;
            updateGenreCommand.Genre = new() { IsActive = true, Name = name };


            UpdateGenreCommandValidator validator = new();
            var result = validator.Validate(updateGenreCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
