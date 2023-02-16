using Microsoft.EntityFrameworkCore;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Contexts
{
    public class MovieStoreAPIDbContext:DbContext
    {
        public MovieStoreAPIDbContext(DbContextOptions<MovieStoreAPIDbContext> options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
