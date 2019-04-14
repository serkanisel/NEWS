using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordStudy.WebApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        bool Add(T entity);
        
        bool Update(T entity);

        bool Delete(T entity);
        
        int Count(Func<T, bool> predicate);

        
    }
}
