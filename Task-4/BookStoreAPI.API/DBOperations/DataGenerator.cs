using BookStoreAPI.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.API.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreAPIDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreAPIDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                 new Book {Title = "Book 1", GenreId = 1, PageCount = 100, PublishDate = new DateTime(2023, 12, 23) },
                 new Book { Title = "Book 2", GenreId = 2, PageCount = 200, PublishDate = new DateTime(2023, 12, 23) },
                 new Book {Title = "Book 3", GenreId = 2, PageCount = 300, PublishDate = new DateTime(2023, 12, 23) });
                context.SaveChanges();
            }
        }
    }
}
