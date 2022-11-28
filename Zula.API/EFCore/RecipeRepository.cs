using Microsoft.Extensions.Logging;
using Zula.API.Models;

namespace Zula.API.EFCore
{
    public class RecipeRepository : GenericRepository<Recipe>, Interfaces.Repositories.IRecipeRepository
    {
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeRepository(DBContext dBContext, ILogger<RecipeRepository> logger) : base(dBContext)
        {
            _logger = logger;
        }
    }
}
