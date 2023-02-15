using BookStoreAPI.API.Application.AuthorOperations.UpdateAuthor;
using BookStoreAPI.API.Application.BookOperations.UpdateBook;
using BookStoreAPI.UnitTests.TestSetup;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("d","",-1)]
        [InlineData("d","", 5)]
        [InlineData("","d", -1)]
        [InlineData("","d", 5)]
        [InlineData("d","d", -1)]
        [InlineData("d","d", 5)]
        [InlineData("dd","", -1)]
        [InlineData("dd","", 5)]
        [InlineData("","dd", -1)]
        [InlineData("","dd", 5)]
        [InlineData("dd","dd", -1)]
        [InlineData("dd","dd", 5)]
        [InlineData("ddd","", -1)]
        [InlineData("ddd","", 5)]
        [InlineData("","ddd", -1)]
        [InlineData("","ddd", 5)]
        [InlineData("dddd","ddd",-1)]    
        [InlineData("dddd","ddd", 5)]
        public void xx(string name,string surname, int authorId)
        {
            UpdateAuthorCommand updateAuthorCommand = new(null);
            updateAuthorCommand.AuthorId = authorId;
            updateAuthorCommand.Author = new() { Name = name, Surname = surname, Birthday = DateTime.Now.AddDays(-20) };

            UpdateAuthorCommandValidator validator = new();
            var result = validator.Validate(updateAuthorCommand);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void yy()
        {
            UpdateAuthorCommand updateAuthorCommand = new(null);
            updateAuthorCommand.AuthorId = 10;
            updateAuthorCommand.Author = new() { Name = "TestDeneme", Surname = "TestDeneme", Birthday = DateTime.Now.AddDays(-20) };

            UpdateAuthorCommandValidator validator = new();
            var result = validator.Validate(updateAuthorCommand);

            result.Errors.Count.Should().Be(0);
        }
    }
}
