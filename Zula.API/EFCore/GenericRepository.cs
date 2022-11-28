using Zula.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zula.API.EFCore
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, Models.IEntityNumeric
    {
        protected DBContext _context;

        public GenericRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
