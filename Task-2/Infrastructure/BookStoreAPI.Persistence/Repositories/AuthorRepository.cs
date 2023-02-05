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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly DbSet<Author> _authors;
        public AuthorRepository(BookStoreAPIDbContext context) : base(context)
        {
            _authors =  context.Set<Author>(); ;
        }
        //yazar sorgulama
        public async Task<Author> FilterByAuthorAsync(string name, string surname)
            => await _authors.Include(x=>x.Books).FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Surname.ToLower() == surname.ToLower());
    }
}
