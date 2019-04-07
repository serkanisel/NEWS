﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WordStudy.WebApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Count(Func<T, bool> predicate);

        
    }
}
