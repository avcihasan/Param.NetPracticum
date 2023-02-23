
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStore.Domain.Entities;

namespace MovieStore.Persistence.Contexts
{
    public class MovieStoreAPIDbContext:IdentityDbContext<BaseUser, BaseRole, int>
    {
        public MovieStoreAPIDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieActor>()
                .HasKey(key => new { key.MovieId, key.ActorId });

            modelBuilder.Entity<Movie>()
                 .HasMany(p => p.Actors)
                 .WithOne(p => p.Movie)
                 .HasForeignKey(p => p.MovieId).OnDelete(DeleteBehavior.ClientSetNull); 

            modelBuilder.Entity<Actor>()
                .HasMany(c => c.Movies)
                .WithOne(c => c.Actor)
                .HasForeignKey(c => c.ActorId).OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);

        }
    }
}
