using System.Collections.Generic;
using System.Threading.Tasks;
using Zula.API.Models;

namespace Zula.API.Handlers
{
    public interface IRecipesHandler
    {
        public Task<Recipe> GetRecipeAsync(int id);
        public Task<IEnumerable<RecipeIngredient>> GetIngredientsByProduct(string query);
        public Task UpdateIngredientsList(IEnumerable<RecipeIngredient> ingredients);
    }
}
