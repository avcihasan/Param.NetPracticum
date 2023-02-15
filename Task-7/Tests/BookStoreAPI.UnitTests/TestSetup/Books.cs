using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreAPIDbContext context)
        {
            context.Books.AddRange(
                 new Book { Title = "Book 1", GenreId = 1, PageCount = 100, PublishDate = new DateTime(2023, 12, 23), AuthorId = 1, IsActive = true },
                 new Book { Title = "Book 2", GenreId = 2, PageCount = 200, PublishDate = new DateTime(2023, 12, 23), AuthorId = 2, IsActive = true },
                 new Book { Title = "Book 3", GenreId = 3, PageCount = 300, PublishDate = new DateTime(2023, 12, 23), AuthorId = 3, IsActive = true });
        }
    }
}
