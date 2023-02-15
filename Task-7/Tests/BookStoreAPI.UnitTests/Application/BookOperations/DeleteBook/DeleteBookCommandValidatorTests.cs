using BookStoreAPI.API.Application.BookOperations.DeleteBook;
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
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturn(int id)
        {
            DeleteBookCommand deleteBookCommand = new(null);
            deleteBookCommand.BookId = id;

            DeleteBookCommandValidator validator = new();
            var result = validator.Validate(deleteBookCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            DeleteBookCommand deleteBookCommand = new(null);
            deleteBookCommand.BookId = 1;

            DeleteBookCommandValidator validator = new();
            var result = validator.Validate(deleteBookCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
