using BookStoreAPI.API.Application.AuthorOperations.UpdateAuthor;
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

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]  
        public void WhenGivenAuthorIdIsNotinDB_InvalidOperationException_ShouldBeReturn()
        {
            UpdateAuthorCommand updateAuthorCommand = new(_context);
            updateAuthorCommand.AuthorId = 0;

            FluentActions.Invoking(() => updateAuthorCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Belirtilen Id'ye sahip yazar mevcut değildir.");
        }

        [Fact]
        public void WhenGivenAuthorIdIsinDB_InvalidOperationException_ShouldNotBeReturnError()
        {
            Author author = new() { Name="Test deneme",Surname="Test deneme",Birthday=DateTime.Now.AddDays(-20)};
            _context.Authors.Add(author);
            _context.SaveChanges();

            UpdateAuthorCommand updateAuthorCommand = new(_context);
            updateAuthorCommand.AuthorId = author.Id;
            updateAuthorCommand.Author = new() { Name = "Test deneme update", Surname = "Test deneme update", Birthday = DateTime.Now.AddDays(-20) };

            FluentActions.Invoking(() => updateAuthorCommand.Handle()).Invoke();

            author.Name.Should().Be(updateAuthorCommand.Author.Name);
            author.Surname.Should().Be(updateAuthorCommand.Author.Surname);
            author.Birthday.Should().Be(updateAuthorCommand.Author.Birthday);
        }
    }
}
