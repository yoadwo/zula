using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntityNumeric
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
