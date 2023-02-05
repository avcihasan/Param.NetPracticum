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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly DbSet<Book> _books;
        public BookRepository(BookStoreAPIDbContext context) : base(context)
        {
            _books= context.Set<Book>(); 
        }
        //isme göre kitap sorgulama
        public async Task<Book> FilterByNameAsync(string name)
            =>  await _books.Include(x => x.Author).Include(x => x.Genre).FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());

        //bütün kitapları bütün özellikleri ile getiren metot
        public async Task<List<Book>> GetAllBooksWithAllPropertiesAsync()
           => await _books.Include(x => x.Author).Include(x => x.Genre).ToListAsync();

        //id si verilen kitabı bütün özellikleri ile getiren metot
        public async Task<Book> GetBookByIdWithAllPropertiesAsync(int id)
            => await _books.Include(x => x.Author).Include(x => x.Genre).FirstOrDefaultAsync(x=>x.Id==id);

    }
}
