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

        protected void Save() => _context.SaveChanges();
        protected async Task SaveAscync()
        {
            await _context.SaveChangesAsync();
        }
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count(); 
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public async Task CreateAsync(T entity)
        {
            _context.Add(entity);
            await SaveAscync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await SaveAscync();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
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

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await SaveAscync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
