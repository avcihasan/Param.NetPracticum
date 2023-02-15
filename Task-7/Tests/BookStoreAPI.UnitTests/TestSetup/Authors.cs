using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreAPIDbContext context)
        {
            context.Authors.AddRange(
               new Author { Name = "yazar1", Surname = "yazar1", Birthday = DateTime.Now },
               new Author { Name = "yazar2", Surname = "yazar2", Birthday = DateTime.Now },
               new Author { Name = "yazar3", Surname = "yazar3", Birthday = DateTime.Now }
             );
        }
    }
}
