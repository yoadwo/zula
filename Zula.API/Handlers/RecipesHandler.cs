using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Zula.API.Interfaces.Repositories;
using Zula.API.Models;

namespace Zula.API.Handlers
{
    public class RecipesHandler : IRecipesHandler
    {
        private readonly Interfaces.ExternalApis.IRecipesApi _recipesApi;
        private readonly IUnitOfWork _unitOfWork;


        public RecipesHandler(Interfaces.ExternalApis.IRecipesApi recipesApi, IUnitOfWork unitOfWork)
        {
            _recipesApi = recipesApi;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<RecipeIngredient>> GetIngredientsByProduct(string query)
        {
            var recipes = await _recipesApi.GetAllRecipesAsync(query);
            // until a better logic is determined,
            // just take the one with most ingredients
            var recipe = recipes.Aggregate((agg, next) =>
                next.MissedIngredientCount > agg.MissedIngredientCount ? next : agg);
            return recipe.MissedIngredients;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await _unitOfWork.Recipes.GetById(id);
        }

        public Task UpdateIngredientsList(IEnumerable<RecipeIngredient> ingredients)
        {
            throw new System.NotImplementedException();
        }
    }
}
