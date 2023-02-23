using AutoMapper;
using BookStoreAPI.API.DBOperations;
using BookStoreAPI.API.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreAPIDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
   

        public CommonTestFixture()
        {
            DbContextOptions<BookStoreAPIDbContext> options = new DbContextOptionsBuilder<BookStoreAPIDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
            Context = new(options);

            Context.Database.EnsureCreated();
            Context.AddAuthors();
            Context.AddGenres();
            Context.AddBooks();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MapProfile>(); }).CreateMapper();
        }
    }
}
