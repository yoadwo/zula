using System;
using System.Threading.Tasks;
using Zula.API.Interfaces.Repositories;

namespace Zula.API.EFCore
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        public IRecipeRepository Recipes { get; private set; }

        public UnitOfWork(DBContext context, IRecipeRepository recipeRepository)
        {
            _context = context;
            Recipes = recipeRepository;
        }

        public Task CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
