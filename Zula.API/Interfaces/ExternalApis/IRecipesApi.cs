using System.Collections.Generic;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Interfaces.ExternalApis
{
    public interface IRecipesApi
    {
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync(string query);
    }
}
