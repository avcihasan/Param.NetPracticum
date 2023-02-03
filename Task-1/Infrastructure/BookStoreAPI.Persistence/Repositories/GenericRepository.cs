using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStoreAPI.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly BookStoreAPIDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(BookStoreAPIDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public IQueryable<T> GetAll()
           => _dbSet.AsQueryable(); 
      
        public async Task<T> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);
            
        public bool Remove(T entity)
        {
            EntityEntry entityEntry = _dbSet.Remove(entity);
            return entityEntry.State==EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry= _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
