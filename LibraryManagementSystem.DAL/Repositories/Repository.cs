using LibraryManagementSystem.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Linq.Expressions;
using LibraryManagementSystem.DAL.Models;
using System.Data.Entity;

namespace LibraryManagementSystem.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected LibraryDbContext _context { get; set; }

        public Repository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<DbSet<T>> GetDbSetAsync()
        {
            return await Task.Run(() => { return _context.Set<T>(); });
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return await _context.Set<T>().Where(condition).ToListAsync();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }

        public async Task AddAsync(T Entity)
        {
            await Task.Run(() => _context.Set<T>().Add(Entity));
            await SaveAsync();
        }

        public void Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T Entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(Entity));
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _context.Set<T>().ToList();
            }); 
        }

        public async Task<int> CountAllAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
