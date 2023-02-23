using Castle.Core.Resource;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTests.TestSetup
{
    public static class AddEntities
    {
        public static void AddActors(this MovieStoreAPIDbContext context)
        {
            context.Actors.AddRange(
                new Actor() { Name = "Actor1", Surname = "Actor1", UserName = "Actor1" },
                new Actor() { Name = "Actor2", Surname = "Actor2", UserName = "Actor2" }
            );
        }

        public static void AddCustomers(this MovieStoreAPIDbContext context)
        {
            context.Customers.AddRange(
                new Customer() { Name = "Customer1", Surname = "Customer1", UserName = "Customer1" },
                new Customer() { Name = "Customer2", Surname = "Customer2", UserName = "Customer2" }
            );
        }

        public static void AddDirectors(this MovieStoreAPIDbContext context)
        {
            context.Directors.AddRange(
                new Director() { Name = "Director1", Surname = "Director1", UserName = "Director1" },
                new Director() { Name = "Director2", Surname = "Director2", UserName = "Director2" }
            );
        }

        public static void AddGenres(this MovieStoreAPIDbContext context)
        {
            context.Genres.AddRange(
                new Genre() { Name = "Genre1" },
                new Genre() { Name = "Genre2" }
            );
        }


        public static void AddMovies(this MovieStoreAPIDbContext context)
        {
            context.Movies.AddRange(
                new Movie() { Name = "Movie1", DirectorId = 1, GenreId = 1, Price = 100, Year = 2010 },
                new Movie() { Name = "Movie2", DirectorId = 2, GenreId = 2, Price = 100, Year = 2011 }

            );
        }
    }
}
