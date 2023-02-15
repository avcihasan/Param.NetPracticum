using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreAPIDbContext context)
        {
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
        }
    }
}
