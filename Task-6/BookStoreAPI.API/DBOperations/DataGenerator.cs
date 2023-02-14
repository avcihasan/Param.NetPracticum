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
                 new Book {Title = "Book 1", GenreId = 1, PageCount = 100, PublishDate = new DateTime(2023, 12, 23) ,AuthorId=1,IsActive=true},
                 new Book { Title = "Book 2", GenreId = 2, PageCount = 200, PublishDate = new DateTime(2023, 12, 23), AuthorId = 2 , IsActive = true },
                 new Book {Title = "Book 3", GenreId = 3, PageCount = 300, PublishDate = new DateTime(2023, 12, 23),  AuthorId = 3 , IsActive = true });

                context.Authors.AddRange(
                new Author {Name="yazar1",Surname= "yazar1", Birthday=DateTime.Now  },
                new Author {Name= "yazar2", Surname= "yazar2", Birthday=DateTime.Now  },
                new Author {Name= "yazar3", Surname= "yazar3", Birthday=DateTime.Now  }
              );
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Genre 1 "
                    },
                    new Genre
                    {
                        Name = "Genre 2 "
                    },
                    new Genre
                    {
                        Name = "Genre 3 "
                    }
                );

                

        

                context.SaveChanges();
            }
        }
    }
}
