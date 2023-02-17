using BookStoreAPI.Application.Repositories;
using MovieStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Application.Repositories
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        IQueryable<Movie> GetAllMoviesWithAllProperties();
    }
}
