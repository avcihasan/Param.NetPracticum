using BookStoreAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Repositories;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieStoreAPIDbContext context) : base(context)
        {
        }

        public  IQueryable<Movie> GetAllMoviesWithAllProperties()
            => _dbSet.Include(x => x.Actors).Include(x => x.Director).Include(x=>x.Genre).AsQueryable();
        
    }
}
