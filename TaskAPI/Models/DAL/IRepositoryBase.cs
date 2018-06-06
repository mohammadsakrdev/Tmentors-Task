﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskAPI.Models.DAL
{
    public interface IRepositoryBase<T> : IDisposable
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
