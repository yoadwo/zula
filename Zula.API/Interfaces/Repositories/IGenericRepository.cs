﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        // not sure how to make async
        // find() must receive object[]: params, not  expressionFunc:expression
        //Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

        //void AddRange(IEnumerable<T> entities);        
        //void RemoveRange(IEnumerable<T> entities);
    }
}
