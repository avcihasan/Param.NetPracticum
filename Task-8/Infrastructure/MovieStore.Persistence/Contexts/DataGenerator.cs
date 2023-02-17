using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Contexts
{
    public static class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreAPIDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreAPIDbContext>>()))
            {

                if (context.Genres.Any())
                {
                    return;
                }


                context.Actors.AddRange(
                    new Actor() { Name = "Actor1", Surname = "Actor1"},
                    new Actor() { Name = "Actor2", Surname = "Actor2" },
                    new Actor() { Name = "Actor3", Surname = "Actor3" }
                    );
                context.Directors.AddRange(
                    new Director() { Name = "Director1", Surname = "Director1" },
                    new Director() { Name = "Director2", Surname = "Director2" },
                    new Director() { Name = "Director3", Surname = "Director3" }
                    );
                context.Customers.AddRange(
                    new Customer() { Name = "Customer1", Surname = "Customer1", },
                    new Customer() { Name = "Customer2", Surname = "Customer2", },
                    new Customer() { Name = "Customer3", Surname = "Customer3", }
                    );

                context.Genres.AddRange(
                    new Genre() { Name = "Genre1" },
                    new Genre() { Name = "Genre2" },
                    new Genre() { Name = "Genre3" }
                    );
                context.Movies.AddRange(
                    new Movie() { DirectorId = 1, GenreId = 1, Name = "Movie1", Price = 100, Year = 2021},
                    new Movie() { DirectorId = 2, GenreId = 2, Name = "Movie2", Price = 100, Year = 2022},
                    new Movie() { DirectorId = 3, GenreId = 3, Name = "Movie3", Price = 100, Year = 2023}
                    );


                context.SaveChanges();
            }
        }

    }
}
