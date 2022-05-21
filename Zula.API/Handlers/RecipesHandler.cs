using System.Collections.Generic;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Handlers
{
    public class RecipesHandler : IRecipesHandler
    {
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> GetRecipeAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recipe> OnPostUploadAsync(Recipe newRecipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
