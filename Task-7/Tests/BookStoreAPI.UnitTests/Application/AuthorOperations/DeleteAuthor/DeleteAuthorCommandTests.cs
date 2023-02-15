using BookStoreAPI.API.Application.AuthorOperations.DeleteAuthor;
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

namespace BookStoreAPI.UnitTests.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreAPIDbContext _context;
        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void xxx()
        {
            DeleteAuthorCommand deleteAuthorCommand = new(_context);
            deleteAuthorCommand.AuthorId = 0;

            FluentActions.Invoking(()=> deleteAuthorCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek yazar bulunamadı");
        }

        [Fact]
        public void yyy()
        {
            Author author = new() { Name = "deneme", Surname = "deneme", Birthday = DateTime.Now.AddDays(-50) };
            _context.Authors.Add(author);
            _context.SaveChanges();

            Book book = new() { IsActive = true, AuthorId = author.Id, GenreId = 1, PageCount = 100, Title = "deneme", PublishDate = DateTime.Now.AddDays(-20) };
            _context.Books.Add(book);
            _context.SaveChanges();

            DeleteAuthorCommand deleteAuthorCommand = new(_context);
            deleteAuthorCommand.AuthorId = author.Id;

            FluentActions.Invoking(() => deleteAuthorCommand.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazarın aktif kitabı olduğu için yazar silinemez");
        }


        [Fact]
        public void zzzz()
        {
            Author author = new() { Name = "deneme", Surname = "deneme", Birthday = DateTime.Now.AddDays(-50) };
            _context.Authors.Add(author);
            _context.SaveChanges();
            DeleteAuthorCommand deleteAuthorCommand = new(_context);
            deleteAuthorCommand.AuthorId = author.Id;

            FluentActions.Invoking(() => deleteAuthorCommand.Handle()).Invoke();
            Author deletedAuthor = _context.Authors.FirstOrDefault(x=>x.Id==author.Id);

            deletedAuthor.Should().BeNull();
        }
    }
}
