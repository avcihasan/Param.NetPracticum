using AutoMapper;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieStore.Application.Mapping;
using MovieStore.Application.Repositories;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using MovieStore.Persistence.Repositories;
using MovieStore.Persistence.Services;

namespace MovieStore.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreAPIDbContext Context { get; set; }
        public IActorService ActorService{ get; set; }
        public IGenericRepository<Actor> ActorRepository { get; set; }

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

            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            
     
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MapProfile>(); }).CreateMapper();
            ActorRepository = new GenericRepository<Actor>(Context);
            ActorService = new ActorService(ActorRepository,Mapper, loggerFactory.CreateLogger<ActorService>());
            
        }
    }
}
