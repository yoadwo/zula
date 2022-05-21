using System.Collections.Generic;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Handlers
{
    public interface IRecipesHandler
    {
        public Task<Recipe> GetRecipeAsync(string id);        
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        public Task<Recipe> OnPostUploadAsync(Recipe newRecipe);
    }
}
