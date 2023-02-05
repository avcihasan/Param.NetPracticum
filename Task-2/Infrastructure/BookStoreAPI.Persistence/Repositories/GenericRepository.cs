using BookStoreAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Persistence.Contexts;
using BookStoreAPI.Domain.Entities;
using System.Globalization;

namespace BookStoreAPI.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
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
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry = _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAllByPropertyNameToAscending(string propertyName)
            => _dbSet.AsQueryable().OrderBy(x => EF.Property<Object>(x, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propertyName.ToLower())));

        public IQueryable<T> GetAllByPropertyNameToDescending(string propertyName)
            => _dbSet.AsQueryable().OrderByDescending(x => EF.Property<Object>(x, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propertyName.ToLower())));
    }
}
