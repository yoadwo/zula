using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(string query)
        {
            return await _recipesApi.GetAllRecipesAsync(query);
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await _unitOfWork.Recipes.GetById(id);
        }

        public Task<Recipe> OnPostUploadAsync(Recipe newRecipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
