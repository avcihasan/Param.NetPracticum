using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Mapping;
using MovieStore.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreAPIDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            DbContextOptions<MovieStoreAPIDbContext> options = new DbContextOptionsBuilder<MovieStoreAPIDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            Context = new(options);

            Context.Database.EnsureCreated();
            Context.AddActors();
            Context.AddCustomers();
            Context.AddDirectors();
            Context.AddGenres();
            Context.AddMovies();
           
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MapProfile>(); }).CreateMapper();
        }
    }
}
