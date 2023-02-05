using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Domain.Entities;
using BookStoreAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Persistence.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly DbSet<Genre> _genres;
        public GenreRepository(BookStoreAPIDbContext context) : base(context)
        {
            _genres=context.Set<Genre>();
        }

        public async Task<Genre> FilterByGenreAsync(string name)
            => await _genres.Include(x => x.Books).FirstOrDefaultAsync(x => x.Name.ToLower()==name.ToLower());
    }
}
