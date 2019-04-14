using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordStudy.WebApi.Interfaces;
using WordStudy.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WordStudy.WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EWSDbContext _context;

        public Repository(EWSDbContext context)
        {
            _context = context;
        }

        protected bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        protected async Task<bool> SaveAscync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public bool Add(T entity)
        {
            _context.Add(entity);
            return Save();
        }

        public async Task<bool> AddAsync(T entity)
        {
            _context.Add(entity);
            return await SaveAscync();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return await SaveAscync();
        }

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await SaveAscync();
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Save();
        }
    }
}
